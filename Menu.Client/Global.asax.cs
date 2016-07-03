using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Menu.Client.Controllers.Core;
using Menu.Client.Mappings;
using Menu.Common;
using Menu.IoCLoader;

namespace Menu.Client
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Dependencies.InitContainer(IoCInitializer.GetContainer(ApplicationType.Client));

            var castleControllerFactory = new CastleControllerFactory(Dependencies.Container);
            ControllerBuilder.Current.SetControllerFactory(castleControllerFactory);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfiguration.Configure();
        }
    }
}
