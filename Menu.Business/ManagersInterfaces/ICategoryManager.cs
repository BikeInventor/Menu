using System.Collections.Generic;
using Menu.Business.Core;
using Menu.Contracts.DataContracts;

namespace Menu.Business.ManagersInterfaces
{
    public interface ICategoryManager : IManager<CategoryDto>
    {
        long AddCategory(CategoryDto menuItem);

        CategoryDto GetCategory(long id);

        IEnumerable<CategoryDto> GetCategories();

        void UpdateCategory(CategoryDto oldItem);

        void DeleteCategory(long id);
    }
}
