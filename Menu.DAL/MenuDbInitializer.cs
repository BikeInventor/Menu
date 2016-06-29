using System.Data.Entity;
using Menu.Data;
using Menu.DAL.Core;
using Menu.DAL.Core.Interfaces;

namespace Menu.DAL
{
    class MenuDbInitializer : DropCreateDatabaseIfModelChanges<MenuDbContext>
    {
        protected override void Seed(MenuDbContext db)
        {
            //TODO: впихнуть при помощи IoC
            IUnitOfWork unitOfWork = new UnitOfWork();

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
