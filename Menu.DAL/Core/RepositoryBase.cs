using System.Collections.Generic;
using System.Data.Entity;
using Menu.Data.Core;

namespace Menu.DAL.Core
{
    public class RepositoryBase<T> where T : DomainObject
    {
        protected MenuDbContext dbContext;
        protected DbSet<T> entityContext;

        protected RepositoryBase(MenuDbContext dbContext)
        {
            this.dbContext = dbContext;
            entityContext = dbContext.Set<T>();
        }

        public T Get(int id)
        {
            return entityContext.Find(id);
        }
        
        public IEnumerable<T> GetAll()
        {
            return entityContext;
        }

        public void Add(T entity)
        {
            entityContext.Add(entity);
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

    }
}
