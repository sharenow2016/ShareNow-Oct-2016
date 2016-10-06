using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShareNow.ViewModel
{
    public class PayVM
    {
        [Required]
        [Display(Name ="Group Member")]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public int Amount { get; set; }
    }
}