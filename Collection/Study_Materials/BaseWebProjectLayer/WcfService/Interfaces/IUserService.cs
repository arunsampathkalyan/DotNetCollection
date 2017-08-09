using System.ServiceModel;
using WcfService.Model;

namespace WcfService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        UserServiceModel Login(UserServiceModel userServiceModel);
    }
}
