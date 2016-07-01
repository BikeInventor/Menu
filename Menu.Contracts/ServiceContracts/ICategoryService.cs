using System.Collections.Generic;
using System.ServiceModel;
using Menu.Contracts.DataContracts;

namespace Menu.Contracts.ServiceContracts
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        long AddCategory(CategoryData category);

        [OperationContract]
        CategoryData GetCategory(long id);

        [OperationContract]
        IEnumerable<CategoryData> GetCategories();

        [OperationContract]
        void UpdateCategory(CategoryData oldCategory);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        void DeleteCategory(long id);
    }
}
