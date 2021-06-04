namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviePropChange : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Movies", new[] { "NumberInStock" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Movies", "NumberInStock", unique: true);
        }
    }
}
