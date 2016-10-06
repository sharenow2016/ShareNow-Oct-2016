using ShareNow.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShareNow.ViewModel
{
    public class GroupVM
    {
        public GroupVM(int groupId)
        {
            AvailableUsers = ShareNowDAL.GetUsers(groupId);
        }
        public GroupVM()
        {
            AvailableUsers = new List<UsersList>();
        }
        
        public IEnumerable<UsersList> AvailableUsers { get; set; }
        public int[] SubmittedUsers { get; set; }
        [Required]
        [Display(Name ="Group Name")]
        public string GroupName { get; set; }
    }
}