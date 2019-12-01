namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValuestoGenre : DbMigration
    {
        public override void Up()
        {
            //Sql("Insert into Genres(ID,Name) values(1,'Drama') ");
            Sql("Insert into Genres(Name) values('Family') ");
            Sql("Insert into Genres(Name) values('Romance') ");
            Sql("Insert into Genres(Name) values('Thriller') ");
            Sql("Insert into Genres(Name) values('Action') ");
            Sql("Insert into Genres(Name) values('Horror') ");

        }

        public override void Down()
        {
        }
    }
}
