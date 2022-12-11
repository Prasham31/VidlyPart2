namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MembershipTypeid", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeid");
            AddForeignKey("dbo.Customers", "MembershipTypeid", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeid", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeid" });
            DropColumn("dbo.Customers", "MembershipTypeid");
            DropTable("dbo.MembershipTypes");
        }
    }
}
