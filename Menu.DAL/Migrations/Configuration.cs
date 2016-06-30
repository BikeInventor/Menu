using Menu.Data;
using Menu.DAL.Core;
using Menu.DAL.Core.Interfaces;
using System.Data.Entity.Migrations;
using Menu.Common;

namespace Menu.DAL.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Menu.DAL.MenuDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Menu.DAL.MenuDbContext";
        }

        protected override void Seed(Menu.DAL.MenuDbContext context)
        {
            IUnitOfWork unitOfWork = Dependencies.Container.Resolve<IUnitOfWork>();

            var beer = new MenuItem() { Name = "Балтика 9", Amount = "0.5л", Price = 100.0M };
            var meat = new MenuItem() { Name = "Стейк из свинины", Amount = "250гр.", Price = 500.0M };
            var salad = new MenuItem() { Name = "Салат 'Цезарь'", Amount = "200гр.", Price = 350.0M };

            unitOfWork.MenuItems.Add(beer);
            unitOfWork.MenuItems.Add(meat);
            unitOfWork.MenuItems.Add(salad);

            unitOfWork.Save();
        }
    }
}
