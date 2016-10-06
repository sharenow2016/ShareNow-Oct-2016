using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ShareNow.ViewModel
{
    public class SignUpVM
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Mobile No")]
        public string Mobile { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Conform Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConformPassword { get; set; }
        //public SNEntities.Enum.UserCategory UserCategory { get; set; }
    }
}