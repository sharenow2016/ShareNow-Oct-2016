using EntityManager;
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
            //SignUpVM viewModel = new SignUpVM();
            //User model = new User();
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "FirstName,LastName,Email,UserName,Password,Mobile,Category")] Users user)
        {
            if (ModelState.IsValid)
            {
                user.IsActive = true;
                user.IsDelete = false;
                user.IsGroup = false;
                ShareNowDBEntities db = new ShareNowDBEntities();
                db.Users.Add(user);
                db.SaveChanges();
                return View(user);
            }
            {
                return View(user);
            }
        }
    }
}