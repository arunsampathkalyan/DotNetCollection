using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JabMvcAjaxDemo.Models;
using JabMvcAjaxDemo.DAL;

namespace JabMvcAjaxDemo.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            List<StudentModel> lstStudents = StudentDAL.GetAllStudents();
            return View(lstStudents);            
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Create(FormCollection collection)
        {
            StudentModel studentModel = new StudentModel();
            TryUpdateModel(studentModel);
            if (!StudentDAL.InsertStudentDetails(studentModel))
            {
                List<StudentModel> lstStudents = StudentDAL.GetAllStudents();
                return PartialView("ViewUserDetails", lstStudents);
            }
            else
            {
                ModelState.AddModelError("ErrorMessage", "Exception while adding student details.");
                return PartialView("UserCreation", studentModel);
            }                        
        }

        public ActionResult UserCreation()
        {
            return PartialView("UserCreation");
        }


    }
}
