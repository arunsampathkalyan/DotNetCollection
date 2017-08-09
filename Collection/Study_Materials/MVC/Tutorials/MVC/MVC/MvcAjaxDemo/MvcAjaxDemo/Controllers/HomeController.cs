using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAjaxDemo.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public string GetStatus()
        {
            return "Status OK at " + DateTime.Now.ToLongTimeString();
        }

        public string UpdateForm(string textBox1)
        {
            if (textBox1 != "Enter Text")
            {
                return "You Entered: \"" + textBox1.ToString() + "\" at " + DateTime.Now.ToLongTimeString();
            }

            return string.Empty;
        }
    }
}
