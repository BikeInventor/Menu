using Menu.Data;
using Menu.DAL.Core;
using Menu.DAL.RepositoryInterfaces;

namespace Menu.DAL.Repositories
{
    public class MenuItemRepository : RepositoryBase<MenuItem, int>, IMenuItemRepository
    {
        public MenuItemRepository(MenuDbContext dbContext) : base(dbContext)
        {
        }

    }
}
