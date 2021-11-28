namespace Vidly_Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES(1, 0, 0, 0, 'Guest')");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES(2, 30, 1, 10, 'Fan')");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES(3, 90, 3, 15, 'Enjoyer')");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES(4, 300, 12, 20, 'Aesthete')");
        }
        
        public override void Down()
        {
        }
    }
}
