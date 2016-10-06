using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShareNow.ViewModel
{
    public class LoginVM
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsValidLogin { get; set; }

        public string ReturnUrl { get; set; }

        //public SNEntities.Enum.UserCategory UserCategory { get; set; }
    }
}