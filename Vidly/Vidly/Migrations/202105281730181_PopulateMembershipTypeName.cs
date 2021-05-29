namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Newbee' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Partner' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Loyal Member' WHERE Id = 4");
        }

        public override void Down()
        {
        }
    }
}
