using System.Collections.Generic;
using Menu.Contracts.ServiceContracts;
using System.ServiceModel;
using Menu.Contracts.DataContracts;

namespace Menu.Proxies
{
    public class CategoryClient : ClientBase<ICategoryService>, ICategoryService
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
