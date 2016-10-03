using ShareNow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareNow.ViewModel
{
    public class ShareVM
    {
        public ShareVM(int groupId)
        {
            AvailableUsers = ShareNowDAL.GetUsers(groupId);
        }
        
        public IEnumerable<Users> AvailableUsers { get; set; }
        public int[] SubmittedUsers { get; set; }
        public int Amount { get; set; }
        public string Category { get; set; }
    }

    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}