﻿using System.Collections.Generic;
using Menu.Business.ManagersInterfaces;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;
using Menu.Common;

namespace Menu.Service
{
    public class MenuService : ServiceBase, IMenuService
    {
        private readonly IMenuManager _menuManager;

        public MenuService()
        {
            _menuManager = Dependencies.Container.Resolve<IMenuManager>();
        }

        public int AddMenuItem(MenuItemData menuItem)
        {
           return ExecuteWithExceptionHandling(() => _menuManager.AddMenuItem(menuItem));
        }

        public void DeleteMenuItem(int id)
        {
            ExecuteWithExceptionHandling(() => _menuManager.DeleteMenuItem(id));
        }

        public MenuItemData GetMenuItem(int id)
        {
            return ExecuteWithExceptionHandling(() => _menuManager.GetMenuItem(id));
        }

        public IEnumerable<MenuItemData> GetMenuItems()
        {
            return ExecuteWithExceptionHandling(() => _menuManager.GetMenuItems());
        }

        public void UpdateMenuItem(MenuItemData updatedItem)
        {
            ExecuteWithExceptionHandling(() => _menuManager.UpdateMenuItem(updatedItem));
        }
    }
}
