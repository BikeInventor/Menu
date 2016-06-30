using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu.Contracts.DataContracts;

namespace Menu.Business.ManagersInterfaces
{
    public interface IMenuManager
    {
        int AddMenuItem(MenuItemData menuItem);

        MenuItemData GetMenuItem(int id);

        IEnumerable<MenuItemData> GetMenuItems();

        void UpdateMenuItem(MenuItemData oldItem);

        void DeleteMenuItem(int id);
    }
}
