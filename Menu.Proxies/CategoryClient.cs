using System.Collections.Generic;
using Menu.Contracts.ServiceContracts;
using Menu.Contracts.DataContracts;
using Menu.Proxies.Core;

namespace Menu.Proxies
{
    public class CategoryClient : DisposableClientBase<ICategoryService>, ICategoryService
    {
        public long AddCategory(CategoryDto category)
        {
            return Channel.AddCategory(category);
        }

        public CategoryDto GetCategory(long id)
        {
            return Channel.GetCategory(id);
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            return Channel.GetCategories();
        }

        public void UpdateCategory(CategoryDto oldCategory)
        {
            Channel.UpdateCategory(oldCategory);
        }

        public void DeleteCategory(long id)
        {
            Channel.DeleteCategory(id);
        }
    }
}
