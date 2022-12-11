namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameValueToMembershipInDb : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes Set Name = 'Pay as You Go' where Id = 1");
            Sql("Update MembershipTypes Set Name = 'Monthly' where Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
