using System.Collections.Generic;
using System.ServiceModel;
using Menu.Contracts.DataContracts;

namespace Menu.Contracts.ServiceContracts
{
    [ServiceContract]
    public interface IMenuService : IServiceContract
    {
        [OperationContract]
        int AddMenuItem(MenuItemData menuItem);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MenuItemData GetMenuItem(int id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IEnumerable<MenuItemData> GetMenuItems();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        void UpdateMenuItem(MenuItemData oldItem);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        void DeleteMenuItem(int id);
    }
    
}
