namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvatarAndAboutPropertiesToUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Avatar", c => c.String(maxLength: 200));
            AddColumn("dbo.Users", "About", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "About");
            DropColumn("dbo.Users", "Avatar");
        }
    }
}
