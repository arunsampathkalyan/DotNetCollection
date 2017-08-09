using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using FormAuthDemo.Models;
using System.Configuration;
using FormAuthDemo.DAL;

namespace FormAuthDemo.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        public ActionResult Index()
        {
           List<StudentModel> lstStudents = StudentDAL.GetAllStudents();

           return View(lstStudents);
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(StudentModel model)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                string commandString = "Insert JB_Student values('" + model.StudentName + "', '" +  model.DateOfBirth + "', '" + model.Sex + "', " + model.Adminssion + ", " + model.Income  + ")";
                
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(commandString, connection);
                int rowsAffected  = command.ExecuteNonQuery();

                connection.Close();
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        
        //
        // GET: /Student/Edit/5
 
        public ActionResult Edit(int id)
        {
            StudentModel studentDetails = StudentDAL.GetStudentDetails(id);

            return View(studentDetails);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, StudentModel model)
        {
            try
            {
                model.StudentID = id;

                StudentDAL.UpdateStudentDetails(model);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Delete/5
 
        public ActionResult Delete(int id)
        {
            StudentDAL.DeleteStudentDetails(id);

            return RedirectToAction("Index"); 
        }

        //
        // POST: /Student/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
