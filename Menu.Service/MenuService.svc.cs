using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;
using Menu.Data;
using Menu.DAL.Core;
using Menu.DAL.Core.Interfaces;
using Menu.Service.Mappings;

namespace Menu.Service
{
    public class MenuService : IMenuService
    {
        private IUnitOfWork _unitOfWork;

        public MenuService()
        {
            _unitOfWork = UnitOfWorkFactory.Create();
            AutoMapperConfiguration.Configure();
        }

        public int AddMenuItem(MenuItemData menuItem)
        {
            var newItem = Mapper.Map<MenuItemData, MenuItem>(menuItem);

            _unitOfWork.MenuItems.Add(newItem);
            _unitOfWork.Save();

            return newItem.Id;
        }

        public void DeleteMenuItem(int id)
        {
            var itemToDelete = _unitOfWork.MenuItems.Get(id);

            if (itemToDelete != null)
            {
                _unitOfWork.MenuItems.Delete(itemToDelete);
                _unitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        //TODO: FaultContract'ы
        public MenuItemData GetMenuItem(int id)
        {
            var menuItem = _unitOfWork.MenuItems.Get(id);
            if (menuItem != null)
            {
                return Mapper.Map<MenuItem, MenuItemData>(menuItem);
            }
            return null;
        }

        public IEnumerable<MenuItemData> GetMenuItems()
        {
            return Mapper.Map<IEnumerable<MenuItem>, 
                IEnumerable<MenuItemData>>(_unitOfWork.MenuItems.GetAll());
        }

        public void UpdateMenuItem(MenuItemData updatedItem)
        {
            var creationDateTime = updatedItem.Created;
            var lastEditionDateTime = DateTime.Now;

            var updItem = Mapper.Map<MenuItemData, MenuItem>(updatedItem);

            updItem.Created = creationDateTime;
            updItem.LastEdited = lastEditionDateTime;

            _unitOfWork.MenuItems.Update(updItem);
            _unitOfWork.Save();
        }
    }
}
