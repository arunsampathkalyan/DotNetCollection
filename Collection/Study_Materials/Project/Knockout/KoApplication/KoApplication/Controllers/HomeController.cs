using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KoApplication.Controllers
{
    public class HomeController : Controller
    {        

        public ActionResult Jquery()
        {
            return View();
        }

        public ActionResult Basics()
        {
            return View();
        }

        public ActionResult Templating()
        {
            return View();
        }

        public ActionResult Complete()
        {
            return View();
        }

        public ActionResult Subscribe()
        {
            return View();
        }

        public ActionResult WritableComputedObservable()
        {
            return View();
        }

        public ActionResult ControlFlowBinding()
        {
            return View();
        }

        public ActionResult VirtualElement()
        {
            return View();
        }

        public ActionResult BindingContext()
        {
            return View();
        }

        public ActionResult MultipleViewModels()
        {
            return View();
        }

        public ActionResult CustomBinding()
        {
            return View();
        }

        public ActionResult CustomEventBinding()
        {
            return View();
        }

        public ActionResult ExtendingObservables()
        {
            return View();
        }

        public ActionResult OtherBindings()
        {
            return View();
        }

        public JsonResult Save(Person person)
        {
            string message = string.Format("Saved {0} {1}", person.FirstName, person.LastName);
            message += string.Format(" with {0} friends",person.Friends.Count);
            message += string.Format(" ({0} on Twitter)", person.Friends.Where(x=>x.IsOnTwitter).Count());
            return Json(new { message });
        }
    }
}
