namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostViewsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostViews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PostID = c.Int(nullable: false),
                        IpAddress = c.String(nullable: false, maxLength: 50),
                        Count = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.PostID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostViews", "UserID", "dbo.Users");
            DropForeignKey("dbo.PostViews", "PostID", "dbo.Posts");
            DropIndex("dbo.PostViews", new[] { "PostID" });
            DropIndex("dbo.PostViews", new[] { "UserID" });
            DropTable("dbo.PostViews");
        }
    }
}
