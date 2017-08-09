using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FormAuthDemo.Models;

namespace FormAuthDemo.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {   

            if (model.UserName == "test" && model.Password == "password")
            {
                SetAuthenticationCookie(model.UserName);

                return RedirectToAction("Home");
            }
            else
            {
                ModelState.AddModelError("", "The username or password provided is incorrect.");
            }

            return View(model);
        }


        public virtual void SetAuthenticationCookie(string username)
        {
            FormsAuthentication.SetAuthCookie(username, false);
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}
