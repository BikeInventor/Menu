using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;
using AutoMapper;
using Menu.Client.Models;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;
using Menu.Proxies.Core;

namespace Menu.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenuService _menuClient;
        private readonly ICategoryService _categoryClient;

        public HomeController(IProxyFactory proxyFactory)
        {
            _menuClient = proxyFactory.GetProxy<IMenuService>();
            _categoryClient = proxyFactory.GetProxy<ICategoryService>();
        }

        public ActionResult Index()
        {
            try
            {
                var categories = Mapper.Map<IEnumerable<CategoryData>,
                IEnumerable<CategoryViewModel>>(_categoryClient.GetCategories());

                return View(categories);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel()
                {
                    Title = "Неизвестная ошибка",
                    Message = ex.Message
                });
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ItemViewModel itemViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var menuItem = Mapper.Map<ItemViewModel, MenuItemData>(itemViewModel);
                    _menuClient.AddMenuItem(menuItem);
                }
                return Redirect("/Home/MenuItems");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel()
                {
                    Title = "Неизвестная ошибка",
                    Message = ex.Message
                });
            }          
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Error", new ErrorViewModel()
                {
                    Title = "Ошибка доступа",
                    Message = "Запрошенной страницы не существует"
                });

            try
            {
                var editItem = _menuClient.GetMenuItem(id.Value);
                var allCategories = _categoryClient.GetCategories();

                var notCategoriesOfItem = allCategories
                    .Where(cat => !editItem.Categories
                    .Select(item => item.Id).Contains(cat.Id));

                ViewBag.CategoriesWithoutItem = Mapper.Map<IEnumerable<CategoryData>,
                    IEnumerable<CategoryViewModel>>(notCategoriesOfItem);

                return View(Mapper.Map<MenuItemData, ItemViewModel>(editItem));
            }
            catch (FaultException<NotFoundException> ex)
            {
                return RedirectToAction("Error",
                    Mapper.Map<NotFoundException, ErrorViewModel>(ex.Detail));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel()
                {
                    Title = "Неизвестная ошибка",
                    Message = ex.Message
                });
            }

        }

        [HttpPost]
        public ActionResult Edit(ItemViewModel itemViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var editItem = Mapper.Map<ItemViewModel, MenuItemData>(itemViewModel);
                    editItem.Categories = _menuClient.GetMenuItem(itemViewModel.Id).Categories;

                    _menuClient.UpdateMenuItem(editItem);
                }
                return Redirect("/Home/MenuItems");
            }
            catch (FaultException<NotFoundException> ex)
            {
                return RedirectToAction("Error",
                    Mapper.Map<NotFoundException, ErrorViewModel>(ex.Detail));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel()
                {
                    Title = "Неизвестная ошибка",
                    Message = ex.Message
                });
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Error", new ErrorViewModel()
                {
                    Title = "Ошибка доступа",
                    Message = "Запрошенной страницы не существует"
                });

            try
            {
                _menuClient.DeleteMenuItem(id.Value);
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch (FaultException<NotFoundException> ex)
            {
                return RedirectToAction("Error",
                    Mapper.Map<NotFoundException, ErrorViewModel>(ex.Detail));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new ErrorViewModel()
                {
                    Title = "Неизвестная ошибка",
                    Message = ex.Message
                });
            }
        }

        public ActionResult Error(ErrorViewModel error)
        {
            return View(error);
        }

        public ActionResult MenuItems()
        {
            try
            {
                var menuItems = Mapper.Map<IEnumerable<MenuItemData>,
                IEnumerable<ItemViewModel>>(_menuClient.GetMenuItems());

                return View(menuItems);
            }
            catch (FaultException ex)
            {
                return RedirectToAction("Error", new ErrorViewModel()
                {
                    Title = "Неизвестная ошибка",
                    Message = ex.Message
                });
            }
        }

        public ActionResult IncludeCategory(int id, long catId)
        {
            var category = _categoryClient.GetCategory(catId);
            var menuItem = _menuClient.GetMenuItem(id);

            menuItem.Categories.Add(category);

            _menuClient.UpdateMenuItem(menuItem);

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult ExcludeCategory(int id, long catId)
        {
            var menuItem = _menuClient.GetMenuItem(id);

            menuItem.Categories = menuItem.Categories
                .Where(cat => cat.Id != catId).ToList();

            _menuClient.UpdateMenuItem(menuItem);

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}