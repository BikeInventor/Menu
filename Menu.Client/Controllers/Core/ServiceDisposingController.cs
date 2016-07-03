using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Menu.Contracts;

namespace Menu.Client.Controllers.Core
{
    public class ServiceDisposingController : Controller
    {
        private ICollection<IServiceContract> _services;

        public ICollection<IServiceContract> Services
        {
            get
            {
                _services = _services ?? new List<IServiceContract>();
                return _services;
            }
        }

        protected virtual void RegisterServices(ICollection<IServiceContract> services)
        {
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            RegisterServices(Services);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            foreach (var service in Services)
            {
                (service as IDisposable)?.Dispose();
            }
        }
    }
}