using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShareNow.SNEntities;

namespace ShareNow.ViewModel
{
    public class SignUpVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MailId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConformPassword { get; set; }
        public string MobileNo { get; set; }
        public SNEntities.Enum.UserCategory UserCategory { get; set; }
    }
}