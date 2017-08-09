using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using JabMvcAjaxDemo.Models;

namespace JabMvcAjaxDemo.DAL
{
    public class StudentDAL
    {
        public static List<StudentModel> GetAllStudents()
        {
            List<StudentModel> objStudents = new List<StudentModel>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select StudentID, StudentName, DateOfBirth, Sex, Admission, Income From JB_Student";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        objStudents.Add(new StudentModel()
                        {
                            StudentID = Convert.ToInt32(reader["StudentID"].ToString()),
                            StudentName = reader["StudentName"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString()),
                            Sex = reader["Sex"].ToString(),
                            Adminssion = Convert.ToInt32(reader["Admission"].ToString()),
                            Income = Convert.ToDouble(reader["Income"].ToString())
                        });
                    }
                }
            }
            return objStudents;
        }

        public static StudentModel GetStudentDetails(int studentID)
        {
            StudentModel student = new StudentModel();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select StudentID, StudentName, DateOfBirth, Sex, Admission, Income From JB_Student Where StudentID = " + studentID.ToString();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        student.StudentID = Convert.ToInt32(reader["StudentID"].ToString());
                        student.StudentName = reader["StudentName"].ToString();
                        student.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString());
                        student.Sex = reader["Sex"].ToString();
                        student.Adminssion = Convert.ToInt32(reader["Admission"].ToString());
                        student.Income = Convert.ToDouble(reader["Income"].ToString());
                    }
                }
            }

            return student;
        }

        public static bool UpdateStudentDetails(StudentModel student)
        {
            int rows = 0;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE JB_Student SET StudentName = '" + student.StudentName + "', DateOfBirth = '" + student.DateOfBirth + "', Sex = '" + student.Sex + "', Income = " + student.Income + ", Admission = " + student.Adminssion + " WHERE StudentID = " + student.StudentID;

                    rows = command.ExecuteNonQuery();
                }
            }

            if (rows > 0)
                return true;
            else
                return false;
        }

        public static bool DeleteStudentDetails(int studentID)
        {
            int rows = 0;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM JB_Student WHERE StudentID = " + studentID;

                    rows = command.ExecuteNonQuery();
                }
            }

            if (rows > 0)
                return true;
            else
                return false;
        }

        public static bool InsertStudentDetails(StudentModel model)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            string commandString = "Insert JB_Student values('" + model.StudentName + "', '" + model.DateOfBirth + "', '" + model.Sex + "', " + model.Adminssion + ", " + model.Income + ")";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(commandString, connection);
            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected == 1 ? true : false;
        }
    }
}