using AutoMapper;
using DataAccess;
using IDataAccess;
using Model;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserDataAccess _userDataAccess;

        public UserService(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public User Login(User user)
        {
            var userDetail = Mapper.Map<UserDetail>(user);
            return Mapper.Map<User>(_userDataAccess.Login(userDetail));
        }
    }
}
