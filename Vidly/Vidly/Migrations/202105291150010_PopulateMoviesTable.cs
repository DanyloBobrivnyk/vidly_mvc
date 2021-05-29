namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Title, ReleaseDate, DateAdded, NumberInStock, Price, Genre_Id) VALUES ('Shrek!', '01-24-2002', '02-15-2002', 1, 15.20,5)");
            Sql("INSERT INTO Movies (Title, ReleaseDate, DateAdded, NumberInStock, Price, Genre_Id) VALUES ('TENET', '12-21-2021', '12-26-2021', 2, 8.99,2)");
            Sql("INSERT INTO Movies (Title, ReleaseDate, DateAdded, NumberInStock, Price, Genre_Id) VALUES ('Friends', '02-01-1999', '01-01-2000', 3, 1.25,3)");
        }

        public override void Down()
        {
        }
    }
}
