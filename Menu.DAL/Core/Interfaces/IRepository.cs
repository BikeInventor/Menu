using System.Collections.Generic;

namespace Menu.DAL.Core.Interfaces
{
    public interface IRepository<TEntity, TId>
    {
        TEntity Get(TId id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();

        bool IsExist(TId id);
    }
}
