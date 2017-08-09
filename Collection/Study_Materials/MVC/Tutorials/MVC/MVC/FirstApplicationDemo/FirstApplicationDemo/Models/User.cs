using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
 
namespace FirstApplicationDemo.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        class UserMetaData
        {
            [Required(ErrorMessage = "Username is required")]
            public string Username
            {
                get;
                set;
            }

            [Required(ErrorMessage = "UserTypeId is required")]
            [Range(5, 15, ErrorMessage="User Type Id between 5 and 15")]
            public int UserTypeId
            {
                get;
                set;
            }
        }
    }
}