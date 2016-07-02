using System;
using System.ServiceModel;
using System.Web.Mvc;
using AutoMapper;
using Menu.Client.Models;
using Menu.Contracts.DataContracts;
using Menu.Contracts.ServiceContracts;
using Menu.Proxies.Core;

namespace Menu.Client.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMenuService _menuClient;
        private readonly ICategoryService _categoryClient;

        public CategoryController(IProxyFactory proxyFactory)
        {
            _menuClient = proxyFactory.GetProxy<IMenuService>();
            _categoryClient = proxyFactory.GetProxy<ICategoryService>();
        }

        public ActionResult Get(long id)
        {
            try
            {
                var category = _categoryClient.GetCategory(id);
                var categoryViewModel = Mapper.Map<CategoryData, CategoryViewModel>(category);
                return View(categoryViewModel);
            }
            catch (FaultException<NotFoundException> ex)
            {
                return RedirectToAction("Error", "Home", new
                {
                    error = Mapper.Map<NotFoundException, ErrorViewModel>(ex.Detail)
                });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new ErrorViewModel()
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
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            try
            {
                var category = Mapper.Map<CategoryViewModel, CategoryData>(categoryViewModel);
                _categoryClient.AddCategory(category);
                return Redirect("/Home/Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new ErrorViewModel()
                {
                    Title = "Неизвестная ошибка",
                    Message = ex.Message
                });
            }
        }

        public ActionResult Delete(long id)
        {
            try
            {
                _categoryClient.DeleteCategory(id);
                return Redirect("/Home/Index");
            }
            catch (FaultException<NotFoundException> ex)
            {
                return RedirectToAction("Error", "Home", new
                {
                    error = Mapper.Map<NotFoundException, ErrorViewModel>(ex.Detail)
                });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new ErrorViewModel()
                {
                    Title = "Неизвестная ошибка",
                    Message = ex.Message
                });
            }
        }

    }
}