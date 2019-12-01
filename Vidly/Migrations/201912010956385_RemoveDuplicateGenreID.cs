namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDuplicateGenreID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "GenreID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenreID", c => c.Boolean(nullable: false));
        }
    }
}
