namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatorUserID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        LanguageID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Slug = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 4000),
                        CoverPhoto = c.String(nullable: false, maxLength: 200),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Users", t => t.CreatorUserID)
                .ForeignKey("dbo.Dictionaries", t => t.LanguageID)
                .ForeignKey("dbo.Dictionaries", t => t.StatusID)
                .ForeignKey("dbo.Dictionaries", t => t.TypeID)
                .Index(t => t.CreatorUserID)
                .Index(t => t.CategoryID)
                .Index(t => t.TypeID)
                .Index(t => t.LanguageID)
                .Index(t => t.StatusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "TypeID", "dbo.Dictionaries");
            DropForeignKey("dbo.Posts", "StatusID", "dbo.Dictionaries");
            DropForeignKey("dbo.Posts", "LanguageID", "dbo.Dictionaries");
            DropForeignKey("dbo.Posts", "CreatorUserID", "dbo.Users");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "StatusID" });
            DropIndex("dbo.Posts", new[] { "LanguageID" });
            DropIndex("dbo.Posts", new[] { "TypeID" });
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropIndex("dbo.Posts", new[] { "CreatorUserID" });
            DropTable("dbo.Posts");
        }
    }
}
