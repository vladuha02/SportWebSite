using SportWebSite.Domain.Entities;
using SportWebSite.ServiceModels;
using System.Collections.Generic;

namespace SportWebSite.Services
{
    public interface IUserService
    {
        public UserServiceModel AddNewUser(UserServiceModel userServiceModel);

        public IEnumerable<User> GetAvailableUsers();

        public User GetUserById(string id);

        public User UpdateUser(UserServiceModel userServiceModel);

        public bool RemoveUser(string id);
    }
}
