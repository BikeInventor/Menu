using Castle.Windsor;

namespace Menu.Common
{
    public static class Dependencies
    {
        public static WindsorContainer Container { get; private set; }

        static Dependencies()
        {
            Container = new WindsorContainer();
        }

        public static void InitContainer(WindsorContainer container)
        {
            Container = container;
        }
    }
}
