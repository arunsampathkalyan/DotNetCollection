using AutoMapper;
using DataAccess;
using Model;
using Service.ServiceReference;

namespace Service
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<UserDetail, User>();
            CreateMap<User, UserDetail>();
            CreateMap<User, UserServiceModel>();
            CreateMap<UserServiceModel, User>();
        }
    }

    public static class MappingProfile
    {
        public static void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new WebMappingProfile());  //mapping between Web and Business layer objects
            });
        }
    }
}
