using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Menu.Contracts.ServiceContracts;
using Menu.Proxies;
using Menu.Proxies.Core;

namespace Menu.Client.Util
{
    public class ApplicationCastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IProxyFactory>().ImplementedBy<ProxyFactory>());

            container.Register(Component.For<IMenuService>().ImplementedBy<MenuClient>());
            container.Register(Component.For<ICategoryService>().ImplementedBy<CategoryClient>());

            var controllers = Assembly.GetExecutingAssembly()
                .GetTypes().Where(x => x.BaseType == typeof(Controller)).ToList();

            foreach (var controller in controllers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());
            }

        }
    }
}