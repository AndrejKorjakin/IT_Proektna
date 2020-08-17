namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class popustgameschanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "PopustGames_Id", "dbo.PopustGames");
            DropIndex("dbo.Games", new[] { "PopustGames_Id" });
            AddColumn("dbo.PopustGames", "GameId", c => c.Int(nullable: false));
            AddColumn("dbo.PopustGames", "KorisnikId", c => c.Int(nullable: false));
            CreateIndex("dbo.PopustGames", "GameId");
            CreateIndex("dbo.PopustGames", "KorisnikId");
            AddForeignKey("dbo.PopustGames", "GameId", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PopustGames", "KorisnikId", "dbo.Korisniks", "Id", cascadeDelete: true);
            DropColumn("dbo.Games", "PopustGames_Id");
            DropColumn("dbo.PopustGames", "NovaCena");
            DropColumn("dbo.PopustGames", "PopustGame");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PopustGames", "PopustGame", c => c.Int(nullable: false));
            AddColumn("dbo.PopustGames", "NovaCena", c => c.Single(nullable: false));
            AddColumn("dbo.Games", "PopustGames_Id", c => c.Int());
            DropForeignKey("dbo.PopustGames", "KorisnikId", "dbo.Korisniks");
            DropForeignKey("dbo.PopustGames", "GameId", "dbo.Games");
            DropIndex("dbo.PopustGames", new[] { "KorisnikId" });
            DropIndex("dbo.PopustGames", new[] { "GameId" });
            DropColumn("dbo.PopustGames", "KorisnikId");
            DropColumn("dbo.PopustGames", "GameId");
            CreateIndex("dbo.Games", "PopustGames_Id");
            AddForeignKey("dbo.Games", "PopustGames_Id", "dbo.PopustGames", "Id");
        }
    }
}
