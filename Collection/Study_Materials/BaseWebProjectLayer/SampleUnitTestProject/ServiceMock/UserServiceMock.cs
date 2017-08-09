using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SampleUnitTestProject.ServiceMock
{
    public class UserServiceMock : IUserService
    {
        public User Login(User user)
        {
            return new User { Id = new Guid(), Name = "karthik", Password = "kannan" };
        }
    }
}
