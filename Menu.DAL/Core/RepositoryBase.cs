using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Menu.Data.Core;

namespace Menu.DAL.Core
{
    public class RepositoryBase<TEntity,TEntityId> 
        where TEntity : DomainObject<TEntityId>
        where TEntityId : IComparable
    {
        protected MenuDbContext dbContext;
        protected DbSet<TEntity> entityContext;

        protected RepositoryBase(MenuDbContext dbContext)
        {
            this.dbContext = dbContext;
            entityContext = dbContext.Set<TEntity>();
        }

        public TEntity Get(TEntityId id)
        {
            return entityContext.Find(id);
        }
        
        public IEnumerable<TEntity> GetAll()
        {
            return entityContext;
        }

        public void Add(TEntity entity)
        {
            entityContext.Add(entity);
        }

        public void Update(TEntity entity)
        {
            entityContext.AddOrUpdate(entity);
        }

        public void Delete(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public bool IsExist(TEntityId id)
        {
            return entityContext.Any(entity => entity.Id.ToString().Equals(id.ToString()));
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

    }
}
