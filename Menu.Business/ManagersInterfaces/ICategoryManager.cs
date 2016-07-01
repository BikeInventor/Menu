using System.Collections.Generic;
using Menu.Business.Core;
using Menu.Contracts.DataContracts;

namespace Menu.Business.ManagersInterfaces
{
    public interface ICategoryManager : IManager<CategoryData>
    {
        long AddCategory(CategoryData menuItem);

        CategoryData GetCategory(long id);

        IEnumerable<CategoryData> GetCategories();

        void UpdateCategory(CategoryData oldItem);

        void DeleteCategory(long id);
    }
}
