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
    public class LoginModel
    {
        [Required]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
    }

/*
    public class UserContext
    {
        private int userId;
        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        private int userGroup;
        public int UserGroup
        {
            get
            {
                return userGroup;
            }
            set
            {
                userGroup = value;
            }
        }

        private string role;
        public string Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
            }
        }
    }

    public class RequestContext
    {
        public string langauge;
        public string Language
        {
            get
            {
                return langauge;
            }
            set
            {
                Language = value;
            }
        }
    }
*/

}