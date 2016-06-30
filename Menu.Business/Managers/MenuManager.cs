using System;
using System.Collections.Generic;
using System.ServiceModel;
using AutoMapper;
using Menu.Business.Core;
using Menu.Business.ManagersInterfaces;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;
using Menu.Data;
using Menu.DAL.Core;
using Menu.DAL.Core.Interfaces;

namespace Menu.Business.Managers
{
    public class MenuManager : ManagerBase, IMenuManager
    {
        private IUnitOfWork _unitOfWork = UnitOfWorkFactory.Create();

        public int AddMenuItem(MenuItemData menuItem)
        {
            return ExecuteWithFaultHandling(() =>
            {
                var newItem = Mapper.Map<MenuItemData, MenuItem>(menuItem);

                _unitOfWork.MenuItems.Add(newItem);
                _unitOfWork.Save();

                return newItem.Id;
            });
        }

        public MenuItemData GetMenuItem(int id)
        {
            return ExecuteWithFaultHandling(() =>
            {
                var menuItem = _unitOfWork.MenuItems.Get(id);

                if (menuItem == null)
                {
                    var ex = new NotFoundException
                    {
                        Title = "Ошибка при попытке Создания объекта",
                        Message = "Объект не найден."
                    };
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return Mapper.Map<MenuItem, MenuItemData>(menuItem);

            });
        }

        public IEnumerable<MenuItemData> GetMenuItems()
        {
            return ExecuteWithFaultHandling(() => 
                Mapper.Map<IEnumerable<MenuItem>,
                IEnumerable<MenuItemData>>(_unitOfWork.MenuItems.GetAll()));
        }

        public void UpdateMenuItem(MenuItemData updatedItem)
        {
            ExecuteWithFaultHandling(() =>
            {
               // var itemToUpdate = _unitOfWork.MenuItems.Get(updatedItem.Id);

                if (!_unitOfWork.MenuItems.IsExist(updatedItem.Id))
                {
                    var ex = new NotFoundException
                    {
                        Title = "Ошибка при попытке редактирования объекта",
                        Message = "Объект не найден."
                    };
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                var creationDateTime = updatedItem.Created;
                var lastEditionDateTime = DateTime.Now;

                var updItem = Mapper.Map<MenuItemData, MenuItem>(updatedItem);

                updItem.Created = creationDateTime;
                updItem.LastEdited = lastEditionDateTime;

                _unitOfWork.MenuItems.Update(updItem);
                _unitOfWork.Save();
            });
        }

        public void DeleteMenuItem(int id)
        {
            ExecuteWithFaultHandling(() =>
            {
                var itemToDelete = _unitOfWork.MenuItems.Get(id);

                if (itemToDelete != null)
                {
                    _unitOfWork.MenuItems.Delete(itemToDelete);
                    _unitOfWork.Save();
                }
                else
                {
                    var ex = new NotFoundException
                    {
                        Title = "Ошибка при попытке удаления объекта",
                        Message = "Объект не найден."
                    };
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }
    }
}
