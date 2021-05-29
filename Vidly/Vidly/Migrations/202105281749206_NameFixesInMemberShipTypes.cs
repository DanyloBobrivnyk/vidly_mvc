namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameFixesInMemberShipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Partner' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Loyal Man' WHERE Id = 3");
        }

        public override void Down()
        {
        }
    }
}
