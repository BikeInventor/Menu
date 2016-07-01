using Menu.Data;
using Menu.DAL.Core;
using Menu.DAL.RepositoryInterfaces;

namespace Menu.DAL.Repositories
{
    public class CategoryRepository : RepositoryBase<Category, long>, ICategoryRepository
    {
        public CategoryRepository(MenuDbContext dbContext) : base(dbContext)
        {
        }
    }
}
