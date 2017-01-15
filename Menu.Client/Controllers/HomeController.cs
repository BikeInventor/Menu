using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;
using AutoMapper;
using Menu.Client.Controllers.Core;
using Menu.Client.Models;
using Menu.Contracts;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;
using Menu.Proxies.Core;

namespace Menu.Client.Controllers
{
    public class HomeController : ServiceDisposingController
    {
        private readonly IMenuService _menuService;
        private readonly ICategoryService _categoryService;

        public HomeController(IProxyFactory proxyFactory)
        {
            _menuService = proxyFactory.GetProxy<IMenuService>();
            _categoryService = proxyFactory.GetProxy<ICategoryService>();
        }

        protected override void RegisterServices(ICollection<IServiceContract> services)
        {
            base.RegisterServices(services);
            services.Add(_categoryService);
            services.Add(_categoryService);
        }

        public ActionResult Index()
        {
            try
            {
                var categories = Mapper.Map<IEnumerable<CategoryDto>,
                IEnumerable<CategoryViewModel>>(_categoryService.GetCategories());

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
                    var menuItem = Mapper.Map<ItemViewModel, MenuItemDto>(itemViewModel);
                    _menuService.AddMenuItem(menuItem);
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
                var editItem = _menuService.GetMenuItem(id.Value);
                var allCategories = _categoryService.GetCategories();

                var notCategoriesOfItem = allCategories
                    .Where(cat => !editItem.Categories
                    .Select(item => item.Id).Contains(cat.Id));

                ViewBag.CategoriesWithoutItem = Mapper.Map<IEnumerable<CategoryDto>,
                    IEnumerable<CategoryViewModel>>(notCategoriesOfItem);

                return View(Mapper.Map<MenuItemDto, ItemViewModel>(editItem));
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
                    var editItem = Mapper.Map<ItemViewModel, MenuItemDto>(itemViewModel);
                    editItem.Categories = _menuService.GetMenuItem(itemViewModel.Id).Categories;

                    _menuService.UpdateMenuItem(editItem);
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
                _menuService.DeleteMenuItem(id.Value);
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
                var menuItems = Mapper.Map<IEnumerable<MenuItemDto>,
                IEnumerable<ItemViewModel>>(_menuService.GetMenuItems());

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
            var category = _categoryService.GetCategory(catId);
            var menuItem = _menuService.GetMenuItem(id);

            menuItem.Categories.Add(category);

            _menuService.UpdateMenuItem(menuItem);

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult ExcludeCategory(int id, long catId)
        {
            var menuItem = _menuService.GetMenuItem(id);

            menuItem.Categories = menuItem.Categories
                .Where(cat => cat.Id != catId).ToList();

            _menuService.UpdateMenuItem(menuItem);

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}