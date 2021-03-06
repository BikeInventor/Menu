﻿using System.Collections.Generic;
using Menu.Business.ManagersInterfaces;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;

namespace Menu.Service
{
    public class MenuService : ServiceBase, IMenuService
    {
        private readonly IMenuManager _menuManager;

        public MenuService(IMenuManager menuManager)
        {
            _menuManager = menuManager;
        }

        public int AddMenuItem(MenuItemDto menuItem)
        {
            return ExecuteWithExceptionHandling(() => _menuManager.AddMenuItem(menuItem));
        }

        public void DeleteMenuItem(int id)
        {
            ExecuteWithExceptionHandling(() => _menuManager.DeleteMenuItem(id));
        }

        public MenuItemDto GetMenuItem(int id)
        {
            return ExecuteWithExceptionHandling(() => _menuManager.GetMenuItem(id));
        }

        public IEnumerable<MenuItemDto> GetMenuItems()
        {
            return ExecuteWithExceptionHandling(() => _menuManager.GetMenuItems());
        }

        public void UpdateMenuItem(MenuItemDto updatedItem)
        {
            //ExecuteWithExceptionHandling(() => _menuManager.UpdateMenuItem(updatedItem));
            var a = 1;
            ExecuteWithExceptionHandling(() => _menuManager.UpdateMenuItem(updatedItem));
            var b = 3;
        }
    }
}