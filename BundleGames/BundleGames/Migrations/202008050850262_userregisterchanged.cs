namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userregisterchanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Korisniks", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Korisniks", "Email");
        }
    }
}
