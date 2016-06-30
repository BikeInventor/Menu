using System.Collections.Generic;
using System.Linq;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;
using Menu.Data;
using Menu.DAL.Core;
using Menu.DAL.Core.Interfaces;

namespace Menu.Service
{
    public class MenuService : IMenuService
    {
        private IUnitOfWork _unitOfWork;

        public MenuService()
        {
            _unitOfWork = UnitOfWorkFactory.Create();
        }

        public int AddMenuItem(MenuItemData menuItem)
        {
            var newItem = new MenuItem()
            {
                Name = menuItem.Name,
                Amount = menuItem.Amount,
                Price = menuItem.Price
            };

            _unitOfWork.MenuItems.Add(newItem);
            _unitOfWork.Save();

            return newItem.Id;
        }

        public void DeleteMenuItem(int id)
        {
            var itemToDelete = new MenuItem() {Id = id};

            _unitOfWork.MenuItems.Delete(itemToDelete);
            _unitOfWork.Save();
        }

        //TODO: FaultContract'ы
        public MenuItemData GetMenuItem(int id)
        {
            var menuItem = _unitOfWork.MenuItems.Get(id);
            if (menuItem != null)
            {
                return new MenuItemData()
                {
                    Id = menuItem.Id,
                    Name = menuItem.Name,
                    Amount = menuItem.Amount,
                    Price = menuItem.Price
                };
            }
            return null;
        }

        public IEnumerable<MenuItemData> GetMenuItems()
        {
            var returnItemsList = new List<MenuItemData>();

            _unitOfWork.MenuItems.GetAll().ToList().ForEach(item =>
            {
                returnItemsList.Add(new MenuItemData()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Amount = item.Amount,
                    Price = item.Price
                });
            });

            return returnItemsList;
        }

        public void UpdateMenuItem(MenuItemData oldItem)
        {
            var updItem = new MenuItem()
            {
                Id = oldItem.Id,
                Name = oldItem.Name,
                Amount = oldItem.Amount,
                Price = oldItem.Price
            };

            _unitOfWork.MenuItems.Update(updItem);
            _unitOfWork.Save();
        }
    }
}
