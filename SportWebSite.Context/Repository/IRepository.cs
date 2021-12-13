using System;
using System.Collections.Generic;

namespace SportWebSite.Data.Repository
{
    public interface IRepository<TEntity, TKey> 
        where TEntity : class
        where TKey : IComparable
    {
        public TEntity Add(TEntity entity);

        public TEntity Get(TKey id);

        public IEnumerable<TEntity> GetAll();

        public bool Delete(TKey id);

        public TEntity Update(TEntity entity);
    }
}
