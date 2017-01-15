using System.Data.Entity;
using Menu.Data;

namespace Menu.DAL
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext()
            : base("MenuDBConnection")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

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
