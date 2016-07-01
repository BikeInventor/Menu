using System;
using Menu.Data;
using System.Data.Entity.Migrations;

namespace Menu.DAL.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Menu.DAL.MenuDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Menu.DAL.MenuDbContext";
        }

        protected override void Seed(MenuDbContext context)
        {
            var now = DateTime.Now;

            var beer = new MenuItem() { Name = "Балтика 9", Amount = "0.5л", Price = 100.0M, Created = now, LastEdited = now };
            var meat = new MenuItem() { Name = "Стейк из свинины", Amount = "250гр.", Price = 500.0M, Created = now, LastEdited = now };
            var salad = new MenuItem() { Name = "Салат 'Цезарь'", Amount = "200гр.", Price = 350.0M, Created = now, LastEdited = now };

            context.MenuItems.Add(beer);
            context.MenuItems.Add(meat);
            context.MenuItems.Add(salad);

            context.SaveChanges();
        }
    }
}
