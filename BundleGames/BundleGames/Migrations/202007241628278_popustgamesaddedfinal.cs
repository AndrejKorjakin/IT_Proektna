namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class popustgamesaddedfinal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PopustGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NovaCena = c.Single(nullable: false),
                        PopustGame = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "PopustGames_Id", c => c.Int());
            CreateIndex("dbo.Games", "PopustGames_Id");
            AddForeignKey("dbo.Games", "PopustGames_Id", "dbo.PopustGames", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "PopustGames_Id", "dbo.PopustGames");
            DropIndex("dbo.Games", new[] { "PopustGames_Id" });
            DropColumn("dbo.Games", "PopustGames_Id");
            DropTable("dbo.PopustGames");
        }
    }
}
