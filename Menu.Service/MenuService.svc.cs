using System.Collections.Generic;
using Menu.Business.Core;
using Menu.Business.Managers;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;
using Menu.Service.Mappings;
using Menu.Business.ManagersInterfaces;
using Menu.Common;
using Menu.DAL;
using Menu.DAL.Core;
using Menu.ServiceImplementation;

namespace Menu.Service
{
    public class MenuService : IMenuService
    {
        private readonly IMenuService _mnuSvcImplementation;

        public MenuService()
        {
            _mnuSvcImplementation = Dependencies.Container.Resolve<IMenuService>();
        }

        public int AddMenuItem(MenuItemData menuItem)
        {
           return _mnuSvcImplementation.AddMenuItem(menuItem);
        }

        public void DeleteMenuItem(int id)
        {
            _mnuSvcImplementation.DeleteMenuItem(id);
        }

        public MenuItemData GetMenuItem(int id)
        {
            return _mnuSvcImplementation.GetMenuItem(id);
        }

        public IEnumerable<MenuItemData> GetMenuItems()
        {
            return _mnuSvcImplementation.GetMenuItems();
        }

        public void UpdateMenuItem(MenuItemData updatedItem)
        {
            _mnuSvcImplementation.UpdateMenuItem(updatedItem);
        }
    }
}
