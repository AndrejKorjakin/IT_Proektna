namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgametocardmodeladded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddGameToCardModels",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddGameToCardModels", "KorisnikId", "dbo.Korisniks");
            DropForeignKey("dbo.AddGameToCardModels", "GameId", "dbo.Games");
            DropIndex("dbo.AddGameToCardModels", new[] { "KorisnikId" });
            DropIndex("dbo.AddGameToCardModels", new[] { "GameId" });
            DropTable("dbo.AddGameToCardModels");
        }
    }
}
