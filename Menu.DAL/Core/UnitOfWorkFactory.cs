using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Menu.DAL.Core.Interfaces;

namespace Menu.DAL.Core
{
    public class UnitOfWorkFactory
    {
        public static IUnitOfWork Create()
        {
            IWindsorContainer container = new WindsorContainer(); 

            container.Register(Component.For<MenuDbContext>()
                .ImplementedBy<MenuDbContext>()
                .LifestyleSingleton());

            container.Register(Classes.FromThisAssembly()
                .BasedOn(typeof(IRepository<,>))
                .WithServiceAllInterfaces());

            container.Register(Component.For<IUnitOfWork>()
                .ImplementedBy<UnitOfWork>());

            return container.Resolve<IUnitOfWork>();
        }
    }
}
