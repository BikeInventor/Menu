using Menu.DAL.RepositoryInterfaces;

namespace Menu.DAL.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IMenuItemRepository MenuItems { get; set; }
        ICategoryRepository Categories { get; set; }
        void Save();
    }
}
