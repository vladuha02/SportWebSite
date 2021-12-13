using Microsoft.EntityFrameworkCore;
using SportWebSite.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SportWebSite.Data.Repository
{
    public class UserRepository : IRepository<User, string>
    {
        private readonly SportContext _context;

        public UserRepository(SportContext context)
        {
            _context = context;
        }

        public User Add(User user)
        {
            _context.Users.Add(user);

            return user;
        }

        public bool Delete(string id)
        {
            if (id != null)
            {
                User user = Get(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    return true;
                }
            }
            return false;
        }

        public User Get(string id)
        {
            return _context.Users.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.AsEnumerable();
        }

        public User Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return user;
        }
    }
}