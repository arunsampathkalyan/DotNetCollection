using Model;
using Service.ServiceReference;
using AutoMapper;
using System.ServiceModel;
using System.Configuration;

namespace Service.ServiceClass
{
    public class UserServiceWCF : IUserService
    {
        public User Login(User user)
        {
            var userServiceClient = new UserServiceClient();

            var userServiceModel = Mapper.Map<UserServiceModel>(user);

            userServiceModel = userServiceClient.Login(userServiceModel);

            var userService = GetUserService().CreateChannel();
            userServiceModel = userService.Login(userServiceModel);

            return Mapper.Map<User>(userServiceModel);
        }

        private static ChannelFactory<ServiceReference.IUserService> GetUserService()
        {
            var requestUrl = ConfigurationManager.AppSettings["UserServiceAPI"];
            BasicHttpBinding basicBinding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(requestUrl);
            ChannelFactory<ServiceReference.IUserService> userService = new ChannelFactory<ServiceReference.IUserService>(basicBinding, endpoint);
            return userService;
        }
    }
}
