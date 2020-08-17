namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkoutadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "ShoppingCart_Id", "dbo.ShoppingCarts");
            DropIndex("dbo.Games", new[] { "ShoppingCart_Id" });
            CreateTable(
                "dbo.GameForBuyings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        KorisnikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Korisniks", t => t.KorisnikId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.KorisnikId);
            
            DropColumn("dbo.Games", "ShoppingCart_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "ShoppingCart_Id", c => c.Int());
            DropForeignKey("dbo.GameForBuyings", "KorisnikId", "dbo.Korisniks");
            DropForeignKey("dbo.GameForBuyings", "GameId", "dbo.Games");
            DropIndex("dbo.GameForBuyings", new[] { "KorisnikId" });
            DropIndex("dbo.GameForBuyings", new[] { "GameId" });
            DropTable("dbo.GameForBuyings");
            CreateIndex("dbo.Games", "ShoppingCart_Id");
            AddForeignKey("dbo.Games", "ShoppingCart_Id", "dbo.ShoppingCarts", "Id");
        }
    }
}
