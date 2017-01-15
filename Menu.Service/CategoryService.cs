using System.Collections.Generic;
using Menu.Business.ManagersInterfaces;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;

namespace Menu.Service
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryService(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public long AddCategory(CategoryDto category)
        {
            return ExecuteWithExceptionHandling(() => _categoryManager.AddCategory(category));
        }

        public void DeleteCategory(long id)
        {
            ExecuteWithExceptionHandling(() => _categoryManager.DeleteCategory(id));
        }

        public CategoryDto GetCategory(long id)
        {
            return ExecuteWithExceptionHandling(() => _categoryManager.GetCategory(id));
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            return ExecuteWithExceptionHandling(() => _categoryManager.GetCategories());
        }

        public void UpdateCategory(CategoryDto updatedCategory)
        {
            ExecuteWithExceptionHandling(() => _categoryManager.UpdateCategory(updatedCategory));
        }
    }
}