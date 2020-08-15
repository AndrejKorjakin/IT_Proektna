namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtocartaddded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "GameId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingCarts", "GameId");
        }
    }
}
