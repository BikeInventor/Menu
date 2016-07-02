using Castle.Windsor;
using Menu.IoCLoader.Installers;

namespace Menu.IoCLoader
{
    public enum ApplicationType
    {
        Client,
        Service
    }

    public class IoCInitializer
    {
        public static WindsorContainer GetContainer(ApplicationType appType)
        {
            var container = new WindsorContainer();

            if (appType == ApplicationType.Service)
                container.Install(new ServiceDependenciesInstaller());
            else
                container.Install(new ClientDependenciesInstaller());

            return container;
        }
    }
}