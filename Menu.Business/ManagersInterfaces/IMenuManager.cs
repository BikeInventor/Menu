using System.Collections.Generic;
using Menu.Business.Core;
using Menu.Contracts.DataContracts;

namespace Menu.Business.ManagersInterfaces
{
    public interface IMenuManager : IManager<MenuItemData>
    {
        int AddMenuItem(MenuItemData menuItem);

        MenuItemData GetMenuItem(int id);

        IEnumerable<MenuItemData> GetMenuItems();

        void UpdateMenuItem(MenuItemData oldItem);

        void DeleteMenuItem(int id);
    }
}
