using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApplicationDemo.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index(int id)
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC! - " + id.ToString();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
