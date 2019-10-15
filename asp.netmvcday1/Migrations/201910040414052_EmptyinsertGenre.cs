namespace asp.netmvcday1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyinsertGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Genres(Name)values('Comedy')");

            Sql("Insert Genres(Name)values('Science Fiction')");

            Sql("Insert Genres(Name)values('Thriller')");

            Sql("Insert Genres(Name)values('Horror')");

        }
        
        public override void Down()
        {
        }
    }
}
