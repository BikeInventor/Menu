using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Menu.Business.Core;
using Menu.DAL;
using Menu.DAL.Core;
using Menu.DAL.Core.Interfaces;

namespace Menu.Bootstrapper
{
    public class ServiceDependenciesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyInThisApplication()
               .BasedOn(typeof(IManager<>))
               .WithServiceAllInterfaces());

            container.Register(Component.For<IUnitOfWork>()
                .ImplementedBy<UnitOfWork>()
                .LifestyleSingleton());

            container.Register(Classes.FromAssemblyInThisApplication()
                .BasedOn(typeof(IRepository<,>))
                .WithServiceAllInterfaces());

            container.Register(Component.For<MenuDbContext>()
                .ImplementedBy<MenuDbContext>()
                .LifestyleSingleton());
        }
    }
}
