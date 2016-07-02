using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Menu.Business.Core;
using Menu.Business.Exceptions;
using Menu.Business.ManagersInterfaces;
using Menu.Contracts.DataContracts;
using Menu.Data;
using Menu.DAL.Core.Interfaces;

namespace Menu.Business.Managers
{
    public class MenuManager : ManagerBase, IMenuManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddMenuItem(MenuItemData menuItem)
        {
            var newItem = Mapper.Map<MenuItemData, MenuItem>(menuItem);
            newItem.Created = DateTime.Now;
            newItem.LastEdited = DateTime.Now;

            _unitOfWork.MenuItems.Add(newItem);
            _unitOfWork.Save();

            return newItem.Id;
        }

        public MenuItemData GetMenuItem(int id)
        {
            var menuItem = _unitOfWork.MenuItems.Get(id);

            if (menuItem == null)
            {
                throw new ObjectNotFoundException()
                {
                    Title = "Ошибка при обращении к объекту",
                    Message = "Объект не найден."
                };

            }

            return Mapper.Map<MenuItem, MenuItemData>(menuItem);
        }

        public IEnumerable<MenuItemData> GetMenuItems()
        {
            return Mapper.Map<IEnumerable<MenuItem>,
                    IEnumerable<MenuItemData>>(_unitOfWork.MenuItems.GetAll());
        }

        public void UpdateMenuItem(MenuItemData updatedItem)
        {
            var itemToUpdate = _unitOfWork.MenuItems.Get(updatedItem.Id);
            if (itemToUpdate == null)
            {
                throw new ObjectNotFoundException
                {
                    Title = "Ошибка при попытке редактирования объекта",
                    Message = "Объект не найден."
                };
            }

            itemToUpdate.LastEdited = DateTime.Now;
            itemToUpdate.Name = updatedItem.Name;
            itemToUpdate.Amount = updatedItem.Amount;
            itemToUpdate.Price = updatedItem.Price;

            itemToUpdate.Categories.Clear();     
            updatedItem.Categories.ToList()
                .ForEach(c =>
                {
                    itemToUpdate.Categories.Add(_unitOfWork.Categories.Get(c.Id));
                });

            _unitOfWork.MenuItems.Update(itemToUpdate);
            _unitOfWork.Save();
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
                throw new ObjectNotFoundException
                {
                    Title = "Ошибка при попытке удаления объекта",
                    Message = "Объект не найден."
                };
            }
        }
    }
}
