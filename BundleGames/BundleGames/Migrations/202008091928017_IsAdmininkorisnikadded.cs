namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAdmininkorisnikadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Korisniks", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Korisniks", "IsAdmin");
        }
    }
}
