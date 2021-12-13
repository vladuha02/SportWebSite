using SportWebSite.Domain.Entities;
using System.Collections.Generic;

namespace SportWebSite.Data.Repository
{
    public interface IUnitOfWork
    {
        public void Commit();

        public void Dispose();

        public void UpdateRange(ICollection<Player> entities);

        public void RollBackTransaction();

        public void BeginTransaction();

        public PlayerRepository Players { get; }

        public UserRepository Users { get; }

        public TeamRepository Teams { get; }
    }
}
