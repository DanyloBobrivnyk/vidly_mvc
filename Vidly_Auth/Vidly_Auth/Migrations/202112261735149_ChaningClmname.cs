namespace Vidly_Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChaningClmname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberOfAvailable", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Available");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Available", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "NumberOfAvailable");
        }
    }
}
