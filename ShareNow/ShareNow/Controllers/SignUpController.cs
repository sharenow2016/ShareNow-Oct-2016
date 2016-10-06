using EntityManager;
using ShareNow.DAL;
using ShareNow.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareImmediate.Controllers
{
    public class SignUpController : Controller
    {
        // GET: Signup
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SignUpVM model)
        {

                if (ModelState.IsValid)
                {
                    ShareNowDAL.AddUser(model);
                ViewBag.message = "Welcome to ShareNow ...";
                    return View(model);
                }
            
            {
                ViewBag.message = "Something wrong in signup please contact Admin....";
                return View(model);
            }
        }
    }
}