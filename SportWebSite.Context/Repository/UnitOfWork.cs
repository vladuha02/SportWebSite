using SportWebSite.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SportWebSite.Data.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly SportContext _db;
        private PlayerRepository _playerRepository;
        private TeamRepository _teamRepository;
        private UserRepository _userRepository;
        private bool _disposed = false;

        public UnitOfWork(SportContext db)
        {
            _db = db;
        }

        public PlayerRepository Players
        {
            get
            {
                if (_playerRepository == null)
                    _playerRepository = new PlayerRepository(_db);
                return _playerRepository;
            }
        }

        public TeamRepository Teams
        {
            get
            {
                if (_teamRepository == null)
                    _teamRepository = new TeamRepository(_db);
                return _teamRepository;
            }
        }

        public UserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_db);
                return _userRepository;
            }
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void RollBackTransaction()
        {
            _db.Database.RollbackTransaction();
        }

        public void BeginTransaction()
        {
            _db.Database.BeginTransaction();
        }

        public void UpdateRange(ICollection<Player> players)
        {
            _db.Players.UpdateRange(players);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
