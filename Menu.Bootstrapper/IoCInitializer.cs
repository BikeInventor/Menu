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
        private static WindsorContainer _container;

        public static WindsorContainer GetInitializedContainer()
        {
            _container = new WindsorContainer();

            _container.Register(Classes.FromAssemblyInThisApplication()
                .BasedOn(typeof(IManager<>))
                .WithServiceAllInterfaces());

            _container.Register(Component.For<IUnitOfWork>()
                .ImplementedBy<UnitOfWork>()
                .LifestyleSingleton());

            _container.Register(Classes.FromAssemblyInThisApplication()
                .BasedOn(typeof(IRepository<,>))
                .WithServiceAllInterfaces());

            _container.Register(Component.For<MenuDbContext>()
                .ImplementedBy<MenuDbContext>()
                .LifestyleSingleton());

            return _container;
        }
    }
}
