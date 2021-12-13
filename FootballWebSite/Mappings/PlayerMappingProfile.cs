using AutoMapper;
using SportWebSite.Domain.Entities;
using SportWebSite.ServiceModels;

namespace SportWebSite.Mappings
{
    public class PlayerMappingProfile : Profile
    {
        public PlayerMappingProfile()
        {
            CreateMap<Player, PlayerServiceModel>().ReverseMap();
        }
    }
}
