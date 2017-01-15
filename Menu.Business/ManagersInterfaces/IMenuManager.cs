using System.Collections.Generic;
using Menu.Business.Core;
using Menu.Contracts.DataContracts;

namespace Menu.Business.ManagersInterfaces
{
    public interface IMenuManager : IManager<MenuItemDto>
    {
        int AddMenuItem(MenuItemDto menuItem);

        MenuItemDto GetMenuItem(int id);

        IEnumerable<MenuItemDto> GetMenuItems();

        void UpdateMenuItem(MenuItemDto oldItem);

        void DeleteMenuItem(int id);
    }
}
