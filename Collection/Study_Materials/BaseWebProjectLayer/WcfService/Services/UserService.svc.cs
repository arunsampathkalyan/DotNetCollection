using System;
using System.ServiceModel.Activation;
using WcfService.Model;

namespace WcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UserService : IUserService
    {
        public UserServiceModel Login(UserServiceModel userServiceModel)
        {
            return new UserServiceModel { Id = Guid.NewGuid(), Name = "karthik", Password = "kannan" };
        }
    }
}
