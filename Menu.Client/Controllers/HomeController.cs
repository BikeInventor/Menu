using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Menu.Client.Models;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;

namespace Menu.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenuService _menuClient;

        public HomeController(IMenuService menuClient)
        {
            _menuClient = menuClient;
        }

        public ActionResult Index()
        {
            var viewmodelItems = Mapper.Map<IEnumerable<MenuItemData>, 
                IEnumerable<ItemViewModel>>(_menuClient.GetMenuItems());

            return View(viewmodelItems);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ItemViewModel itemViewModel)
        {
            var menuItem = Mapper.Map<ItemViewModel, MenuItemData> (itemViewModel);
            _menuClient.AddMenuItem(menuItem);
            return Redirect("/Home/Index");
        }

        public ActionResult Edit(int id)
        {
            var editItem = _menuClient.GetMenuItem(id);
            var editItemViewModel = Mapper.Map<MenuItemData, ItemViewModel>(editItem);
            return View(editItemViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ItemViewModel itemViewModel)
        {
            var editItem = Mapper.Map<ItemViewModel, MenuItemData>(itemViewModel);
            _menuClient.UpdateMenuItem(editItem);
            return Redirect("/Home/Index");
        }

        public ActionResult Delete(int id)
        {
            _menuClient.DeleteMenuItem(id);
            return Redirect("/Home/Index");

        }
    }
}