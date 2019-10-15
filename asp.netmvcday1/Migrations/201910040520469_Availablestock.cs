namespace asp.netmvcday1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Availablestock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvailableStock");
        }
    }
}
