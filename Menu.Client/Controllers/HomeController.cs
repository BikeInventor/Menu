using System.Collections.Generic;
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
                var viewmodelItems = Mapper.Map<IEnumerable<MenuItemData>,
               IEnumerable<ItemViewModel>>(_menuClient.GetMenuItems());

                return View(viewmodelItems);
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ItemViewModel itemViewModel)
        {
            try
            {
                var menuItem = Mapper.Map<ItemViewModel, MenuItemData>(itemViewModel);
                _menuClient.AddMenuItem(menuItem);
                return Redirect("/Home/Index");
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

        public ActionResult Edit(int id)
        {
            try
            {
                var editItem = _menuClient.GetMenuItem(id);
                var editItemViewModel = Mapper.Map<MenuItemData, ItemViewModel>(editItem);
                return View(editItemViewModel);
            }
            catch (FaultException<NotFoundException> ex)
            {
                return RedirectToAction("Error",
                    Mapper.Map<NotFoundException, ErrorViewModel>(ex.Detail));
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

        [HttpPost]
        public ActionResult Edit(ItemViewModel itemViewModel)
        {
            try
            {
                var editItem = Mapper.Map<ItemViewModel, MenuItemData>(itemViewModel);
                _menuClient.UpdateMenuItem(editItem);
                return Redirect("/Home/Index");
            }
            catch (FaultException<NotFoundException> ex)
            {
                return RedirectToAction("Error",
                    Mapper.Map<NotFoundException, ErrorViewModel>(ex.Detail));
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

        public ActionResult Delete(int id)
        {
            try
            {
                _menuClient.DeleteMenuItem(id);
                return Redirect("/Home/Index");
            }
            catch (FaultException<NotFoundException> ex)
            {
                return RedirectToAction("Error",
                    Mapper.Map<NotFoundException, ErrorViewModel>(ex.Detail));
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

        public ActionResult Category(long id)
        {
            try
            {
                var category = _categoryClient.GetCategory(id);
                var categoryViewModel = Mapper.Map<CategoryData, CategoryViewModel>(category);
                return View(categoryViewModel);
            }
            catch (FaultException<NotFoundException> ex)
            {
                return RedirectToAction("Error",
                    Mapper.Map<NotFoundException, ErrorViewModel>(ex.Detail));
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

        public ActionResult Error(ErrorViewModel error)
        {
            return View(error);
        }
    }
}