using System;
using System.Collections.Generic;
using System.ServiceModel;
using AutoMapper;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;
using Menu.Data;
using Menu.DAL.Core;
using Menu.DAL.Core.Interfaces;
using Menu.Service.Mappings;
using Menu.Business.Managers;

namespace Menu.Service
{
    public class MenuService : IMenuService
    {
        private MenuManager _menuManager = new MenuManager();

        public MenuService()
        {
            AutoMapperConfiguration.Configure();
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
