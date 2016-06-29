using System.Collections.Generic;
using Menu.Contracts.ServiceContracts;
using System.ServiceModel;
using Menu.Contracts.DataContracts;

namespace Menu.Proxies
{
    public class MenuClient : ClientBase<IMenuService>, IMenuService
    {
        public int AddMenuItem(MenuItemData menuItem)
        {
            return Channel.AddMenuItem(menuItem);
        }

        public MenuItemData GetMenuItem(int id)
        {
            return Channel.GetMenuItem(id);
        }

        public IEnumerable<MenuItemData> GetMenuItems()
        {
            return Channel.GetMenuItems();
        }

        public void UpdateMenuItem(MenuItemData oldItem)
        {
            Channel.UpdateMenuItem(oldItem);
        }

        public void DeleteMenuItem(int id)
        {
            Channel.DeleteMenuItem(id);
        }
    }
}
