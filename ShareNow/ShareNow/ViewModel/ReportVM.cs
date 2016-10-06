using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShareNow.ViewModel
{
    public class ReportVM
    {
        public ReportVM()
        {
            StartDate = DateTime.Now.AddDays(-1);
            EndDate = DateTime.Now;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="End Date")]
        public DateTime EndDate { get; set; }
        public List<ReportDetail> ReportDetails { get; set; }
    }

    public class ReportDetail
    {
        public string UserName { get; set; }
        public int TotalExpense { get; set; }
        public int ShareAmount { get; set; }
        public int PaidAmount { get; set; }
        public int BalanceAmount { get; set; }
    }
}