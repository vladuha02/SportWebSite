using System;
using System.Collections.Generic;
using System.Linq;

namespace SportWebSite.Data.Repository
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> 
        where TEntity: class
        where TKey: IComparable
    {
        private readonly SportContext _context;

        public Repository(SportContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);

            return entity;
        }

        public bool Delete(TKey id)
        {
            TEntity entity = Get(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                return true;
            }

            return false;
        }

        public TEntity Get(TKey id)
        {
            //var entity = _context.Set<TEntity>().FirstOrDefault(f => f.GetType().GetProperty("Id").GetValue(f) == id);

            //return team;
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
