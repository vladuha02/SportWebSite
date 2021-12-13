using SportWebSite.Domain.Entities;
using SportWebSite.ServiceModels;
using System.Collections.Generic;

namespace SportWebSite.Services
{
    public interface IPlayerService
    {
        public void GetPlayersFromAPI();

        public IEnumerable<PlayerServiceModel> GetPlayersFromTeam(int id);

        public PlayerServiceModel AddNewPlayer(PlayerServiceModel serviceModel);

        public Player GetPlayerById(int id);

        public IEnumerable<Player> GetPlayers();

        public bool RemovePlayer(int id);

        public Player UpdatePlayer(PlayerServiceModel playerServiceModel);
    }
}
