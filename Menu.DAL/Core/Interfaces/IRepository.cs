using System.Collections.Generic;

namespace Menu.DAL.Core.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Get(int id);

        IEnumerable<T> GetAll();
    }
}
