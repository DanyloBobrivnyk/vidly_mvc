namespace Vidly_Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES(1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(2, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(3, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(4, 'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(5, 'Mystery')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(6, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(7, 'Thriller')");
        }

        public override void Down()
        {
        }
    }
}
