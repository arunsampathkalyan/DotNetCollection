using Model;
using Service;
using Service.ServiceClass;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BaseWebProjectLayer.Controllers
{
    public class AccountController : Controller
    {
        private static IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            var user = new User() { Name = "karthik", Password = "kannan" };
            var userDetail = _userService.Login(user);
            var wcfUserModel = new UserServiceWCF().Login(user);

            userDetail.Roles = "Admin";
            System.Web.HttpContext.Current.Session["CurrentUser"] = userDetail;

            if (userDetail != null)
            {
                FormsAuthentication.SetAuthCookie(userDetail.Name, false);
                var authTicket = new FormsAuthenticationTicket(1, userDetail.Name, DateTime.Now, DateTime.Now.AddMinutes(20), false, userDetail.Roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "User");
            }

            return Json(wcfUserModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}