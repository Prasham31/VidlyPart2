namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreMembershipTypesInDb : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes Set Name = 'Quarterly' where Id = 3");
            Sql("Update MembershipTypes Set Name = 'Annual' where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
