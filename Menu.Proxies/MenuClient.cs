using System.Collections.Generic;
using Menu.Contracts.ServiceContracts;
using Menu.Contracts.DataContracts;
using Menu.Proxies.Core;

namespace Menu.Proxies
{
    public class MenuClient : DisposableClientBase<IMenuService>, IMenuService
    {
        public int AddMenuItem(MenuItemDto menuItem)
        {
            return Channel.AddMenuItem(menuItem);
        }

        public MenuItemDto GetMenuItem(int id)
        {
            return Channel.GetMenuItem(id);
        }

        public IEnumerable<MenuItemDto> GetMenuItems()
        {
            return Channel.GetMenuItems();
        }

        public void UpdateMenuItem(MenuItemDto oldItem)
        {
            Channel.UpdateMenuItem(oldItem);
        }

        public void DeleteMenuItem(int id)
        {
            Channel.DeleteMenuItem(id);
        }
    }
}
