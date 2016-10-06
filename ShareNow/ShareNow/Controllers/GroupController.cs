using ShareNow.DAL;
using ShareNow.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareNow.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index()
        {
            int goupId = 0;
            if (Session["GroupId"] !=null)
                goupId = (int)Session["GroupId"];
            var model = new GroupVM(goupId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(GroupVM model)
        {
            int goupId = 0;
            var currentUser = (int)Session["UserId"];
            ShareNowDAL.createGroup(model, currentUser);
            if (Session["GroupId"] != null)
                goupId = (int)Session["GroupId"];
            model = new GroupVM(goupId);
            ViewBag.message = "Created Group Successfully......... ";
            return View(model);
        }
    }
}