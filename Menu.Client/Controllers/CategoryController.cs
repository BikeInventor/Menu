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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryClient;

        public CategoryController(IProxyFactory proxyFactory)
        {
            _categoryClient = proxyFactory.GetProxy<ICategoryService>();
        }

        public ActionResult Index(long id)
        {
            try
            {
                var category = _categoryClient.GetCategory(id);
                var categoryViewModel = Mapper.Map<CategoryData, CategoryViewModel>(category);
                return View(categoryViewModel);
            }
            catch (FaultException<NotFoundException> ex)
            {
                return RedirectToAction("LogIn", "Account", new
                {
                    ErrorViewModel = Mapper.Map<NotFoundException, ErrorViewModel>(ex.Detail),
                    area = ""
                });
            }
            //catch (FaultException ex)
            //{
            //    return RedirectToAction("Error", new ErrorViewModel()
            //    {
            //        Title = "Неизвестная ошибка",
            //        Message = ex.Message
            //    });
            //}        
        }

    }
}