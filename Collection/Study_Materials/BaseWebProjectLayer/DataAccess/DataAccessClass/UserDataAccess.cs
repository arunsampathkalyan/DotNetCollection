using IDataAccess;
using System.Linq;

namespace DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly SampleTestEntities _sampleTestEntities = new SampleTestEntities();

        public UserDataAccess()
        { }

        public UserDetail Login(UserDetail userDetail)
        {
            var userEntity = _sampleTestEntities.UserDetails.Where(d => d.Name.Equals(userDetail.Name) && d.Password.Equals(userDetail.Password)).FirstOrDefault();
            return userEntity;
        }
    }
}
