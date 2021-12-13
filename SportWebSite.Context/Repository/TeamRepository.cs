using SportWebSite.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SportWebSite.Data.Repository
{
    public class TeamRepository : IRepository<Team, int>
    {
        private readonly SportContext _context;

        public TeamRepository(SportContext context)
        {
            _context = context;
        }

        public Team Add(Team team)
        {
            _context.Teams.Add(team);

            return team;
        }

        public Team Get(int id)
        {
            var team = _context.Teams.FirstOrDefault(f => f.Id == id);

            return team;
        }

        public IEnumerable<Team> GetAll()
        {
            return _context.Teams;
        }

        public bool Delete(int id)
        {
            Team team = Get(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                return true;
            }

            return false;
        }

        public Team Update(Team team)
        {
            var existingTeam = Get(team.Id);

            if (existingTeam != null)
            {
                existingTeam.Players = team.Players;
                existingTeam.SportType = team.SportType;
                existingTeam.TeamName = team.TeamName;
            }
            return existingTeam;
        }
    }
}