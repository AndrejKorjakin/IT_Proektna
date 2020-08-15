namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagsupdated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "Tags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Tags", c => c.String());
        }
    }
}
