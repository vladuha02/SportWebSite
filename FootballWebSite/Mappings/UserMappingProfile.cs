using AutoMapper;
using SportWebSite.Domain.Entities;
using SportWebSite.ServiceModels;

namespace SportWebSite.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserServiceModel>().ReverseMap();
        }
    }
}
