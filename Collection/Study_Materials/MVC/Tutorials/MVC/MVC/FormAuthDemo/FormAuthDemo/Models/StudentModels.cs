using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Web.Security;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;

namespace FormAuthDemo.Models
{
    public class StudentModel
    {
        [Required]
        public int StudentID
        {
            get;
            set;
        }

        [Required]
        public string StudentName
        {
            get;
            set;
        }
        /*public string FatherName
        {
            get;
            set;
        }
        public string MotherName
        {
            get;
            set;
        }*/

        [Required]
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        [Required]
        public string Sex
        {
            get;
            set;
        }

        [Required]
        public int Adminssion
        {
            get;
            set;
        }

        [Required]
        public double Income
        {
            get;
            set;
        }
     /*   public string CurrentAddress
        {
            get;
            set;
        }
        public string PermanentAddress
        {
            get;
            set;
        }
        public string Religion
        {
            get;
            set;
        }
        public string Caste
        {
            get;
            set;
        }
        public string CasteClass
        {
            get;
            set;
        }        
        public string Nationality
        {
            get;
            set;
        }        
        public DateTime DateOfJoin
        {
            get;
            set;
        }*/
    }
}