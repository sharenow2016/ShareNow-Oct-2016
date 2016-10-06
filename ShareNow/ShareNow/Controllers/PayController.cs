using EntityManager;
using ShareNow.DAL;
using ShareNow.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareNow.Controllers
{
    public class PayController : Controller
    {
        // GET: Pay
        public ActionResult Index()
        {
            int goupId = 0;
            if (Session["GroupId"] != null)
                goupId = (int)Session["GroupId"];
            LoadUsers(goupId);
            return View();
        }

        [HttpPost]
        public ActionResult Index(PayVM model)
        {
            int currentUser = (int)Session["userId"];
            int goupId = 0;
            ShareNowDAL.SavePayment(model, currentUser);
            ViewBag.message = "Payment Completed Successfully.";
            
            if (Session["GroupId"] != null)
                goupId = (int)Session["GroupId"];
            LoadUsers(goupId);
            return View();
        }
        public void LoadUsers(int goupId)
        {
            using (ShareNowDBEntities db = new ShareNowDBEntities())
            {
                var UserId = db.Users.Where(x =>x.GroupId == goupId && x.IsActive == true && x.IsDelete == false)
                    .OrderBy(x =>x.FirstName)
                    .Select(x => new {
                        UserId = x.id,
                        UserName = x.FirstName+" "+x.LastName}
                    ).ToList();
                
                ViewBag.UserId = new SelectList(UserId, "UserId", "UserName","~ select ~");
            }
        }
    }
}