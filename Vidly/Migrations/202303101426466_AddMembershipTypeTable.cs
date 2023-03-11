namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeTable : DbMigration
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
            
            AddColumn("dbo.Customers", "membershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "membershipTypeId");
            AddForeignKey("dbo.Customers", "membershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "membershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "membershipTypeId" });
            DropColumn("dbo.Customers", "membershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
