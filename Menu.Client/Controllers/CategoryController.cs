using System;
using System.Collections.Generic;
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
    public class CategoryController : ServiceDisposingController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(IProxyFactory proxyFactory)
        {
            _categoryService = proxyFactory.GetProxy<ICategoryService>();
        }

        protected override void RegisterServices(ICollection<IServiceContract> services)
        {
            base.RegisterServices(services);
            services.Add(_categoryService);
        }

        public ActionResult Get(long? id)
        {
            if (id == null)
                return RedirectToAction("Error","Home", new ErrorViewModel()
                {
                    Title = "Ошибка доступа",
                    Message = "Запрошенной страницы не существует"
                });
            try
            {
                var category = _categoryService.GetCategory(id.Value);
                var categoryViewModel = Mapper.Map<CategoryDto, CategoryViewModel>(category);
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
                if (ModelState.IsValid)
                {
                    var category = Mapper.Map<CategoryViewModel, CategoryDto>(categoryViewModel);
                    _categoryService.AddCategory(category);
                }
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

        public ActionResult Delete(long? id)
        {
            if (id == null)
                return RedirectToAction("Error", "Home", new ErrorViewModel()
                {
                    Title = "Ошибка доступа",
                    Message = "Запрошенной страницы не существует"
                });
            try
            {
                _categoryService.DeleteCategory(id.Value);
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