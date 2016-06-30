using System.Collections.Generic;
using System.Data.Entity;
using Menu.Data.Core;

namespace Menu.DAL.Core
{
    public class RepositoryBase<TEntity,TEntityId> where TEntity : DomainObject<TEntityId>
    {
        protected MenuDbContext dbContext;
        protected DbSet<TEntity> entityContext;

        protected RepositoryBase(MenuDbContext dbContext)
        {
            this.dbContext = dbContext;
            entityContext = dbContext.Set<TEntity>();
        }

        public TEntity Get(int id)
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
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

    }
}
