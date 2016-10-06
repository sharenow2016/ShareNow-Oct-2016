using EntityManager;
using ShareNow.DAL;
using ShareNow.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShareImmediate.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginVM model, string returnUrl)
        {

            var users = ShareNowDAL.UserAuthendication(model.UserName, model.Password);
           
            if (users != null)
            {
                Session["FirstName"] = users.FirstName;
                Session["LastName"] = users.LastName;
                Session["MailId"] = users.Email;
                Session["UserId"] = users.id;
                Session["UserCategory"] = users.Category;
                Session["GroupId"] = users.GroupId;
                //FormsAuthentication.SetAuthCookie(UserName, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return RedirectToAction(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Pay");
                }
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }
            return View();
        }

    }
}