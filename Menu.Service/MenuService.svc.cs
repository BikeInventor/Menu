using System.Collections.Generic;
using Menu.Business.Core;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;
using Menu.Service.Mappings;
using Menu.Business.ManagersInterfaces;

namespace Menu.Service
{
    public class MenuService : IMenuService
    {
        private readonly IMenuManager _menuManager;

        public MenuService()
        {
            _menuManager = ManagerFactory.GetManager<IMenuManager>();
        }

        public int AddMenuItem(MenuItemData menuItem)
        {
            return _menuManager.AddMenuItem(menuItem);
        }

        public void DeleteMenuItem(int id)
        {
            _menuManager.DeleteMenuItem(id);
        }

        public MenuItemData GetMenuItem(int id)
        {
            return _menuManager.GetMenuItem(id);
        }

        public IEnumerable<MenuItemData> GetMenuItems()
        {
            return _menuManager.GetMenuItems();
        }

        public void UpdateMenuItem(MenuItemData updatedItem)
        {
            _menuManager.UpdateMenuItem(updatedItem);
        }
    }
}
