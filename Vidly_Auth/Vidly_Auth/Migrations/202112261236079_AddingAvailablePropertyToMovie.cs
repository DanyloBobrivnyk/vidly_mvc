namespace Vidly_Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAvailablePropertyToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Available", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Available");
        }
    }
}
