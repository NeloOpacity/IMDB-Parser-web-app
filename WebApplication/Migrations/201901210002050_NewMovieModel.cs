namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Href", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Href");
        }
    }
}
