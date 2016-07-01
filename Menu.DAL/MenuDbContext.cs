using System.Data.Entity;
using Menu.Data;

namespace Menu.DAL
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext()
            : base("MenuDBConnection")
        { }

        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>()
                .HasMany(m => m.Categories)
                .WithMany(c => c.MenuItems)
                .Map(mc =>
                {
                    mc.ToTable("MenuItemCategories");
                    mc.MapLeftKey("MenuItemId");
                    mc.MapRightKey("CategoryId");
                }); ;

            base.OnModelCreating(modelBuilder);
        }

    }

}
