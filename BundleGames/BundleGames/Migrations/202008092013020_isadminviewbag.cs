namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isadminviewbag : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Korisniks", "IsAdmin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Korisniks", "IsAdmin", c => c.Boolean(nullable: false));
        }
    }
}
