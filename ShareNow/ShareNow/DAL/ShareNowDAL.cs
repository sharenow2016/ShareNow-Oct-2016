using EntityManager;
using ShareNow.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace ShareNow.DAL
{
    public class ShareNowDAL
    {

        public static User UserAuthendication(string userName,string password)
        {
            var user = new User();
            using (var db = new ShareNowDBEntities())
            {
                var users = db.Users.Where(u => u.UserName == userName && u.Password == password && u.IsActive == true && u.IsDelete == false).SingleOrDefault();
                if(users != null)
                {
                    user.id = users.id;
                    user.FirstName = users.FirstName;
                    user.LastName = users.LastName;
                    user.Email = users.Email;
                    user.GroupId = users.GroupId;
                    user.Category = users.Category;
                }
                
            }
                return user;
        }

        public static void AddUser(SignUpVM model)
        {
            using (var db = new ShareNowDBEntities())
            {

                var data = new User();
                data.FirstName = model.FirstName;
                data.LastName = model.LastName;
                data.Email = model.Email;
                data.UserName = model.UserName;
                data.Password = model.Password;
                data.Mobile = model.Mobile;
                data.IsActive = true;
                data.IsDelete = false;
                data.Category = "both";
                data.IsActive = true;
                data.IsDelete = false;
                data.IsGroup = false;
                db.Users.Add(data);
                db.SaveChanges();
            }
        }

        public static void SavePayment(PayVM model, int currentUser)
        {
            var newPayment = new Payment();
            using (ShareNowDBEntities db = new ShareNowDBEntities())
            {
                newPayment.RecievedBy = model.UserId;
                newPayment.PaidBy = currentUser;
                newPayment.RecievedDate = DateTime.Now;
                newPayment.Amount = model.Amount;
                db.Payments.Add(newPayment);
                db.SaveChanges();

            }
        }

        public static void SaveShare(ShareVM model, int currentUser)
        {
            var shareAmount = new Share();
            using (ShareNowDBEntities db = new ShareNowDBEntities())
            {
                int noofUsers = model.SubmittedUsers.Count();
                foreach (var user in model.SubmittedUsers)
                {
                    shareAmount.Amount = model.Amount / noofUsers;
                    shareAmount.Category = model.Category;
                    shareAmount.PaidBy = currentUser;
                    shareAmount.SharedBy = user;
                    shareAmount.SharedAt = DateTime.Now;
                    db.Shares.Add(shareAmount);
                    db.SaveChanges();
                }
            }
        }

        public static void createGroup(GroupVM model,int currentUser)
        {
            var newGroup = new Group();
            using(var db = new ShareNowDBEntities())
            {
                    newGroup.GroupName = model.GroupName;
                    newGroup.CreatedAt = DateTime.Now;
                    newGroup.CreatedBy = currentUser;
                    newGroup.IsActive = true;
                    newGroup.IsDelete = false;
                    db.Groups.Add(newGroup);
                    db.SaveChanges();

                var groupId = db.Groups.SingleOrDefault(x => x.GroupName == model.GroupName).Id;

                List<int> users = model.SubmittedUsers.OfType<int>().ToList();
                var groupUsers = db.Users.Where(x => users.Contains(x.id)).ToList();
                groupUsers.ForEach(x =>
                {
                    x.IsGroup = true;
                    x.GroupId = groupId;
                    }
                    );
                db.SaveChanges();
            }

        }

        public static void GetReport()
        {
            using (var db = new ShareNowDBEntities())
            {
            var query = db.Users.Join(
                    db.Shares.Where(x=>x.IsActive == true && x.IsDelete ==false),
                    u => u.id, s => s.SharedBy, (u, s) => new { u, s })
                    .Join(
                    db.Shares.Where(x => x.IsActive == true && x.IsDelete == false)
                    , us => us.u.id, ss => ss.PaidBy, (us, ss) => new { us, ss })
                    .Join(
                    db.Payments.Where(x => x.IsActive == true && x.IsDelete == false)
                    , uss => uss.us.u.id, ps => ps.RecievedBy, (uss, ps) => new { uss, ps })
                    .Join(
                    db.Payments.Where(x => x.IsActive == true && x.IsDelete == false)
                    , ussp => ussp.uss.us.u.id, pys => pys.PaidBy, (ussp, pys) => new { ussp, pys })
                    .ToList();

                //var result = query.



            }
        }

        public static List<UsersList> GetUsers(int groupId)
        {
            
            var result = new List<UsersList>();
            using (var db = new ShareNowDBEntities())
            {
                var UserId = db.Users.Where(x=>x.GroupId == groupId && x.IsActive == true && x.IsDelete == false)
                    .OrderBy(x => x.FirstName)
                    .Select(x => new {
                        UserId = x.id,
                        UserName = x.FirstName + " " + x.LastName
                    }
                    ).ToList();
                foreach(var user in UserId)
                {
                    var data = new UsersList();
                    data.UserId = user.UserId;
                    data.UserName = user.UserName;
                    result.Add(data);
                }
            }
                return result;

        } 
    }
}