using System.Collections.Generic;
using Menu.Contracts.ServiceContracts;
using Menu.Contracts.DataContracts;
using Menu.Proxies.Core;

namespace Menu.Proxies
{
    public class CategoryClient : DisposableClientBase<ICategoryService>, ICategoryService
    {
        public long AddCategory(CategoryData category)
        {
            return Channel.AddCategory(category);
        }

        public CategoryData GetCategory(long id)
        {
            return Channel.GetCategory(id);
        }

        public IEnumerable<CategoryData> GetCategories()
        {
            return Channel.GetCategories();
        }

        public void UpdateCategory(CategoryData oldCategory)
        {
            Channel.UpdateCategory(oldCategory);
        }

        public void DeleteCategory(long id)
        {
            Channel.DeleteCategory(id);
        }
    }
}
