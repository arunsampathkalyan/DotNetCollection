using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JabMvcAjaxDemo.Models
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
    }
}