using System.Collections.Generic;
using System.ServiceModel;
using Menu.Contracts.DataContracts;

namespace Menu.Contracts.ServiceContracts
{
    [ServiceContract]
    public interface IMenuService
    {
        [OperationContract]
        int AddMenuItem(MenuItemData menuItem);

        [OperationContract]
        MenuItemData GetMenuItem(int id);

        [OperationContract]
        IEnumerable<MenuItemData> GetMenuItems();

        [OperationContract]
        void UpdateMenuItem(MenuItemData oldItem);

        [OperationContract]
        void DeleteMenuItem(int id);

    }
    
}
