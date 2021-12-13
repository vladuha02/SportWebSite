using SportWebSite.Domain.Entities;
using SportWebSite.ServiceModels;
using System.Collections.Generic;

namespace SportWebSite.Services
{
    public interface ITeamService
    {
        public TeamServiceModel AddNewTeam(TeamServiceModel serviceModel);

        public void UpdatePlayersTeam(TeamServiceModel teamServiceModel);

        public Team GetTeamById(int id);

        public TeamServiceModel GetServiceModelTeamById(int id);

        public IEnumerable<Team> GetTeams();

        public bool RemoveTeam(int id);

        public Team UpdateTeam(TeamServiceModel teamServiceModel);

        public TeamServiceModel GetAvailablePlayers();
    }
}