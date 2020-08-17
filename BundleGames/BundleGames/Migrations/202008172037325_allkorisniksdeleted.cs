namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allkorisniksdeleted : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Korisniks", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Korisniks", "Image", c => c.String());
        }
    }
}
