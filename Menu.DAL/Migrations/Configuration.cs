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

            var water = new MenuItem() { Name = "����", Amount = "0.5�", Price = 100.0M, Created = now, LastEdited = now };
            var beer = new MenuItem() { Name = "������� 9", Amount = "0.5�", Price = 120.0M, Created = now, LastEdited = now };
            var meat = new MenuItem() { Name = "����� �� �������", Amount = "250��.", Price = 350.0M, Created = now, LastEdited = now };
            var salad = new MenuItem() { Name = "����� '������'", Amount = "200��.", Price = 300.0M, Created = now, LastEdited = now };

            var drinks = new Category()
            {
                Name = "�������",
                Created = now,
                LastEdited = now,
                MenuItems = new List<MenuItem>() { water, beer}
            };

            var food = new Category()
            {
                Name = "���",
                Created = now,
                LastEdited = now,
                MenuItems = new List<MenuItem>() { salad, meat }
            };

            var discount = new Category()
            {
                Name = "������",
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
