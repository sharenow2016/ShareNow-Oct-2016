using ShareNow.DAL;
using ShareNow.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareNow.Controllers
{
    public class ShareController : Controller
    {
        // GET: Share
        public ActionResult Index()
        {
            var goupId = (int)Session["GroupId"];
            var model = new ShareVM(goupId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ShareVM model)
        {
            int currentUser = (int)Session["userId"];

            ShareNowDAL.SaveShare(model, currentUser);
            ViewBag.message = "Payment Completed Successfrully.";
            return View();
        }
    }
}