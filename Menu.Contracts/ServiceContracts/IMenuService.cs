using System.Collections.Generic;
using System.ServiceModel;
using Menu.Contracts.DataContracts;

namespace Menu.Contracts.ServiceContracts
{
    [ServiceContract]
    public interface IMenuService : IServiceContract
    {
        [OperationContract]
        int AddMenuItem(MenuItemDto menuItem);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MenuItemDto GetMenuItem(int id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IEnumerable<MenuItemDto> GetMenuItems();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        void UpdateMenuItem(MenuItemDto oldItem);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        void DeleteMenuItem(int id);
    }
    
}
