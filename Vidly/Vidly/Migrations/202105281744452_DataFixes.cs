namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataFixes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Newbee', SignupFee = 30, DurationInMonths = 1, DiscountRate = 10 WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Newbee', SignupFee = 90, DurationInMonths = 3, DiscountRate = 15 WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Newbee', SignupFee = 300, DurationInMonths = 12, DiscountRate = 20 WHERE Id = 3");
            Sql("DELETE FROM MembershipTypes WHERE Id = 4");
        }

        public override void Down()
        {
        }
    }
}
