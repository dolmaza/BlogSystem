namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostRatingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostRatings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.PostID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostRatings", "UserID", "dbo.Users");
            DropForeignKey("dbo.PostRatings", "PostID", "dbo.Posts");
            DropIndex("dbo.PostRatings", new[] { "UserID" });
            DropIndex("dbo.PostRatings", new[] { "PostID" });
            DropTable("dbo.PostRatings");
        }
    }
}
