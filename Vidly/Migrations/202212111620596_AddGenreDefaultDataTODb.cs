namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreDefaultDataTODb : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(name) values('Comedy')");
            Sql("Insert into Genres(name) values('Action')");
            Sql("Insert into Genres(name) values('Family')");
            Sql("Insert into Genres(name) values('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
