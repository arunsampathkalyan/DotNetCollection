using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApplicationDemo.Controllers
{
    public class ArchiveController : Controller
    {
        //
        // GET: /Archive/

        public ActionResult Entry(DateTime EntryDate)
        {
            ViewData["Message"] = "Welcome to Blog! - " + EntryDate.ToString();

            return View();
        }

    }
}
