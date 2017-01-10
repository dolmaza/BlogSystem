namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCategories",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.CategoryID })
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.UserCategories", "UserID", "dbo.Users");
            DropIndex("dbo.UserCategories", new[] { "CategoryID" });
            DropIndex("dbo.UserCategories", new[] { "UserID" });
            DropTable("dbo.UserCategories");
        }
    }
}
