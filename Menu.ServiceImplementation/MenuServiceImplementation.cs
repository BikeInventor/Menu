using System.Collections.Generic;
using Menu.Business.ManagersInterfaces;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;

namespace Menu.ServiceImplementation
{
    public class MenuServiceImplementation : ServiceImplementationBase, IMenuService
    {
        private readonly IMenuManager _menuManager;

        public MenuServiceImplementation(IMenuManager menuManager)
        {
            _menuManager = menuManager;
        }

        public int AddMenuItem(MenuItemData menuItem)
        {
            return ExecuteWithExceptionHandling(() => _menuManager.AddMenuItem(menuItem));
        }

        public MenuItemData GetMenuItem(int id)
        {
            return ExecuteWithExceptionHandling(() => _menuManager.GetMenuItem(id));
        }

        public IEnumerable<MenuItemData> GetMenuItems()
        {
            return ExecuteWithExceptionHandling(() => _menuManager.GetMenuItems());
        }

        public void UpdateMenuItem(MenuItemData oldItem)
        {
            ExecuteWithExceptionHandling(() => _menuManager.UpdateMenuItem(oldItem));
        }

        public void DeleteMenuItem(int id)
        {
            ExecuteWithExceptionHandling(() => _menuManager.DeleteMenuItem(id));
        }
    }
}
