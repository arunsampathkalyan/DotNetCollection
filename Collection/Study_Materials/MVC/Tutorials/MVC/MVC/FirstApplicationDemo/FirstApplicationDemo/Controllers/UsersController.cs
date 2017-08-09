using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstApplicationDemo.Models;

namespace FirstApplicationDemo.Controllers
{
    public class UsersController : Controller
    {

        ERS_LIVEEntities db = new ERS_LIVEEntities();

        public ActionResult Index()
        {
            var users = from m in db.Users
                        where m.Active == true select m;

            return View(users.ToList());

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User newUser)
        {
            if (ModelState.IsValid)
            {
                db.AddToUsers(newUser);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(newUser);
            }
        }
        
    }
}
