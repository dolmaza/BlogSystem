namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdvertisementTabel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 4000),
                        Url = c.String(nullable: false, maxLength: 200),
                        CoverPhoto = c.String(nullable: false, maxLength: 250),
                        DaysCount = c.Int(nullable: false),
                        PostsCount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dictionaries", t => t.StatusID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.PostAdvertisements",
                c => new
                    {
                        PostID = c.Int(nullable: false),
                        AdvertisementID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostID, t.AdvertisementID })
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Advertisements", t => t.AdvertisementID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.AdvertisementID);
            
            CreateTable(
                "dbo.AdvertisementCategories",
                c => new
                    {
                        AdvertisementID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AdvertisementID, t.CategoryID })
                .ForeignKey("dbo.Advertisements", t => t.AdvertisementID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.AdvertisementID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertisements", "UserID", "dbo.Users");
            DropForeignKey("dbo.Advertisements", "StatusID", "dbo.Dictionaries");
            DropForeignKey("dbo.AdvertisementCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.AdvertisementCategories", "AdvertisementID", "dbo.Advertisements");
            DropForeignKey("dbo.PostAdvertisements", "AdvertisementID", "dbo.Advertisements");
            DropForeignKey("dbo.PostAdvertisements", "PostID", "dbo.Posts");
            DropIndex("dbo.AdvertisementCategories", new[] { "CategoryID" });
            DropIndex("dbo.AdvertisementCategories", new[] { "AdvertisementID" });
            DropIndex("dbo.PostAdvertisements", new[] { "AdvertisementID" });
            DropIndex("dbo.PostAdvertisements", new[] { "PostID" });
            DropIndex("dbo.Advertisements", new[] { "StatusID" });
            DropIndex("dbo.Advertisements", new[] { "UserID" });
            DropTable("dbo.AdvertisementCategories");
            DropTable("dbo.PostAdvertisements");
            DropTable("dbo.Advertisements");
        }
    }
}
