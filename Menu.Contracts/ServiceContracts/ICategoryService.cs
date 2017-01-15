using System.Collections.Generic;
using System.ServiceModel;
using Menu.Contracts.DataContracts;

namespace Menu.Contracts.ServiceContracts
{
    [ServiceContract]
    public interface ICategoryService : IServiceContract
    {
        [OperationContract]
        long AddCategory(CategoryDto category);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CategoryDto GetCategory(long id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IEnumerable<CategoryDto> GetCategories();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        void UpdateCategory(CategoryDto oldCategory);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        void DeleteCategory(long id);
    }
}
