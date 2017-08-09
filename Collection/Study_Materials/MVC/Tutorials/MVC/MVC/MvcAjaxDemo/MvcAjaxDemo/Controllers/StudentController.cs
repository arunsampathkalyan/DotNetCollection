using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAjaxDemo.DAL;
using MvcAjaxDemo.Models;

namespace MvcAjaxDemo.Controllers
{
    public class StudentController : Controller
    {   
        public ActionResult Index()
        {
            List<StudentModel> lstStudents = StudentDAL.GetAllStudents();

            return View(lstStudents);
        }
        
        [HttpPost] 
        public ActionResult Create(FormCollection collection)
        {
            StudentModel studentModel=new StudentModel();            
            TryUpdateModel(studentModel);
            if (StudentDAL.InsertStudentDetails(studentModel))
            {
                List<StudentModel> lstStudents = StudentDAL.GetAllStudents();
                return PartialView("StudentList", lstStudents);
            }
            else
            {
                ModelState.AddModelError("ErrorMessage", "Exception while adding student details.");
                return PartialView("UserCreation", studentModel);
            }            
        }
        
        public ActionResult Create1()
        {
            StudentModel student = new StudentModel();
            return PartialView("UserCreation",student);
        }
    }
}
