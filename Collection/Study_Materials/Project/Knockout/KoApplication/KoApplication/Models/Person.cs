using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KoApplication.Models;

namespace KoApplication.Controllers
{
    public class Person
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public ICollection<Friend> Friends { get; set; }
    }
}
