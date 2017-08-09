using DataAccess;

namespace IDataAccess
{
    public interface IUserDataAccess
    {
        UserDetail Login(UserDetail userDetail);
    }
}
