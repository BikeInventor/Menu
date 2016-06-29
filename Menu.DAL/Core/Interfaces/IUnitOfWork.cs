using Menu.DAL.RepositoryInterfaces;

namespace Menu.DAL.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IMenuItemRepository MenuItems { get; }
        void Save();
    }
}
