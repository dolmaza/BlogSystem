namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReviewColumnToPostRatingTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostRatings", "Review", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostRatings", "Review");
        }
    }
}
