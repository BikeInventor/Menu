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

    }

}
