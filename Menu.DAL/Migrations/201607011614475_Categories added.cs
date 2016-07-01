namespace Menu.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categoriesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastEdited = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuItemCategories",
                c => new
                    {
                        MenuItemId = c.Int(nullable: false),
                        CategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuItemId, t.CategoryId })
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.MenuItemId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItemCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.MenuItemCategories", "MenuItemId", "dbo.MenuItems");
            DropIndex("dbo.MenuItemCategories", new[] { "CategoryId" });
            DropIndex("dbo.MenuItemCategories", new[] { "MenuItemId" });
            DropTable("dbo.MenuItemCategories");
            DropTable("dbo.Categories");
        }
    }
}
