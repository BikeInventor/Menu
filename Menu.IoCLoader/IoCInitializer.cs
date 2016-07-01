using Castle.Windsor;

namespace Menu.IoCLoader.App_Code
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