namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loginregisterpartialviewfixed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Tags");
        }
    }
}
