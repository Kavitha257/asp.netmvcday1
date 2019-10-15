namespace asp.netmvcday1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enablemembership : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Duration = c.Short(nullable: false),
                        SignUpFee = c.Double(nullable: false),
                        Discount = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MembershipTypes");
        }
    }
}
