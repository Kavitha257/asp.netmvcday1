namespace asp.netmvcday1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poplationmigrate : DbMigration
    {
        public override void Up()
        {
            Sql("Insert MembershipTypes(Type,Duration,SignUpFee,Discount) values('Yearly',12,1200,20)");
            Sql("Insert MembershipTypes(Type,Duration,SignUpFee,Discount) values('Monthly',2,1200,20)");
            Sql("Insert MembershipTypes(Type,Duration,SignUpFee,Discount) values('Quarterly',10,1200,20)");
            Sql("Insert MembershipTypes(Type,Duration,SignUpFee,Discount) values('PayasyouLyk',25,1200,20)");
        }
        
        public override void Down()
        {
        }
    }
}
