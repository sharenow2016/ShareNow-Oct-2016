using EntityManager;
using ShareNow.DAL;
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
            LoadUsers();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Payment model)
        {
            int currentUser = (int)Session["userId"];
                
            ShareNowDAL.SavePayment(model, currentUser);
            ViewBag.message = "Payment Completed Successfrully.";
            LoadUsers();
            return View();
        }


        public void LoadUsers()
        {
            using (ShareNowDBEntities db = new ShareNowDBEntities())
            {
                var UserId = db.User1.OrderBy(x =>x.FirstName)
                    .Select(x => new {
                        UserId = x.id,
                        UserName = x.FirstName+" "+x.LastName}
                    ).ToList();
                ViewBag.RecievedBy = new SelectList(UserId, "UserId", "UserName","~ select ~");
            }
        }
    }
}