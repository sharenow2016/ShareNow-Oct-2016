using ShareNow.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public ShareVM()
        {
            AvailableUsers = new List<UsersList>();
        }
        
        public IEnumerable<UsersList> AvailableUsers { get; set; }
        public int[] SubmittedUsers { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public int Amount { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }
    }

    public class UsersList
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}