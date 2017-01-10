namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCaptionRusPropertyToDictionariesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dictionaries", "CaptionRus", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dictionaries", "CaptionRus");
        }
    }
}
