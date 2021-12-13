using SportWebSite.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SportWebSite.Data.Repository
{
    public class PlayerRepository : IRepository<Player, int>
    {
        private readonly SportContext _context;

        public PlayerRepository(SportContext context)
        {
            _context = context;
        }

        public Player Add(Player player)
        {
            _context.Players.Add(player);

            return player;
        }

        public Player Get(int id)
        {
            var player = _context.Players.FirstOrDefault(f => f.Id == id);

            return player;
        }

        public IEnumerable<Player> GetAll()
        {
            return _context.Players;
        }

        public bool Delete(int id)
        {
            Player player = Get(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                return true;
            }
            return false;
        }

        public Player Update(Player player)
        {
            var existingPlayer = Get(player.Id);

            if (existingPlayer != null)
            {
                existingPlayer.Name = player.Name;
                existingPlayer.Nationality = player.Nationality;
                existingPlayer.Position = player.Position;
                existingPlayer.Role = player.Role;
                existingPlayer.CountryOfBirth = player.CountryOfBirth;
                existingPlayer.DateOfBirth = player.DateOfBirth;
            }

            return existingPlayer;
        }
    }
}