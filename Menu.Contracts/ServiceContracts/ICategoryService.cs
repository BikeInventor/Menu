using System.Collections.Generic;
using System.ServiceModel;
using Menu.Contracts.DataContracts;

namespace Menu.Contracts.ServiceContracts
{
    [ServiceContract]
    public interface ICategoryService : IServiceContract
    {
        [OperationContract]
        long AddCategory(CategoryData category);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CategoryData GetCategory(long id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IEnumerable<CategoryData> GetCategories();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        void UpdateCategory(CategoryData oldCategory);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        void DeleteCategory(long id);
    }
}
