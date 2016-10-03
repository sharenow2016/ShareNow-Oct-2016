using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareNow.ViewModel
{
    public class GroupVM
    {
        public IEnumerable<Users> AvailableUsers { get; set; }
        public int[] SubmittedUsers { get; set; }
        public string GroupName { get; set; }
    }
}