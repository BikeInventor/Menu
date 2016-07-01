using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Menu.Business.Core;
using Menu.DAL;
using Menu.DAL.Core;
using Menu.DAL.Core.Interfaces;

namespace Menu.Bootstrapper
{
    public class IoCInitializer
    {
        public static WindsorContainer GetInitializedContainer()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceDependenciesInstaller());

            return container;
        }
    }
}
