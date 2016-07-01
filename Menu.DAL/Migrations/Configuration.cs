using System;
using System.Collections.Generic;
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

            var water = new MenuItem() { Name = "Вода", Amount = "0.5л", Price = 100.0M, Created = now, LastEdited = now };
            var beer = new MenuItem() { Name = "Балтика 9", Amount = "0.5л", Price = 120.0M, Created = now, LastEdited = now };
            var meat = new MenuItem() { Name = "Стейк из свинины", Amount = "250гр.", Price = 350.0M, Created = now, LastEdited = now };
            var salad = new MenuItem() { Name = "Салат 'Цезарь'", Amount = "200гр.", Price = 300.0M, Created = now, LastEdited = now };

            var drinks = new Category()
            {
                Name = "Напитки",
                Created = now,
                LastEdited = now,
                MenuItems = new List<MenuItem>() { water, beer}
            };

            var food = new Category()
            {
                Name = "Еда",
                Created = now,
                LastEdited = now,
                MenuItems = new List<MenuItem>() { salad, meat }
            };

            var discount = new Category()
            {
                Name = "Скидка",
                Created = now,
                LastEdited = now,
                MenuItems = new List<MenuItem>() { beer, salad }
            };

            context.MenuItems.Add(beer);
            context.MenuItems.Add(meat);
            context.MenuItems.Add(salad);
            context.Categories.Add(drinks);
            context.Categories.Add(food);
            context.Categories.Add(discount);

            context.SaveChanges();
        }
    }
}
