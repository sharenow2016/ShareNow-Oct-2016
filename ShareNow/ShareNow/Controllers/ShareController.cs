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
            ViewBag.message = null;
            int goupId = 0;
            if(Session["GroupId"] != null)
             goupId = (int)Session["GroupId"];
            var model = new ShareVM(goupId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ShareVM model)
        {
            int goupId = 0;
            int currentUser = (int)Session["userId"];

            ShareNowDAL.SaveShare(model, currentUser);
            goupId = (int)Session["GroupId"];
            model = new ShareVM(goupId);
            ViewBag.message = "Shared Your Expense Successfrully.";
            return View(model);
        }
    }
}