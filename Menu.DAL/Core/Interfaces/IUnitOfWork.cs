using Menu.DAL.RepositoryInterfaces;

namespace Menu.DAL.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IMenuItemRepository MenuItems { get; }
        ICategoryRepository Categories { get; }
        void Save();
    }
}
