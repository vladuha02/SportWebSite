using AutoMapper;
using SportWebSite.Domain.Entities;
using SportWebSite.ServiceModels;

namespace SportWebSite.Mappings
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            CreateMap<Team, TeamServiceModel>().ReverseMap();
        }
    }
}
