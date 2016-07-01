using System.Collections.Generic;
using Menu.Business.ManagersInterfaces;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;
using Menu.Common;

namespace Menu.Service
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryService()
        {
            _categoryManager = Dependencies.Container.Resolve<ICategoryManager>();
        }

        public long AddCategory(CategoryData category)
        {
           return ExecuteWithExceptionHandling(() => _categoryManager.AddCategory(category));
        }

        public void DeleteCategory(long id)
        {
            ExecuteWithExceptionHandling(() => _categoryManager.DeleteCategory(id));
        }

        public CategoryData GetCategory(long id)
        {
            return ExecuteWithExceptionHandling(() => _categoryManager.GetCategory(id));
        }

        public IEnumerable<CategoryData> GetCategories()
        {
            return ExecuteWithExceptionHandling(() => _categoryManager.GetCategories());
        }

        public void UpdateCategory(CategoryData updatedCategory)
        {
            ExecuteWithExceptionHandling(() => _categoryManager.UpdateCategory(updatedCategory));
        }
    }
}
