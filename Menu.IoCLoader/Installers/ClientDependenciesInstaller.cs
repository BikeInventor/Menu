using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Menu.Contracts;
using Menu.Contracts.ServiceContracts;
using Menu.Proxies;
using Menu.Proxies.Core;

namespace Menu.IoCLoader.Installers
{
    public class ClientDependenciesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(Component.For<IProxyFactory>()
                .ImplementedBy<ProxyFactory>());

            container.Register(Component.For<IMenuService>()
                .ImplementedBy<MenuClient>()
                .LifestyleTransient());

            container.Register(Component.For<ICategoryService>()
                .ImplementedBy<CategoryClient>()
                .LifestyleTransient());

            var type = System.Web.HttpContext.Current.ApplicationInstance.GetType();
            while (type != null && type.Namespace == "ASP")
            {
                type = type.BaseType;
            }

            container.Register(Classes.FromAssembly(type.Assembly)
                .Where(x => x.BaseType.BaseType == typeof (Controller))
                .LifestylePerWebRequest());

        }
    }
}
