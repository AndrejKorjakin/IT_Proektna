namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class controllesandviewsadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Game_Name = c.String(nullable: false),
                        Game_Image = c.String(nullable: false),
                        Game_Cena = c.Single(nullable: false),
                        Game_Info = c.String(nullable: false),
                        Release_Date = c.DateTime(nullable: false),
                        Publisher = c.String(nullable: false),
                        Developer = c.String(nullable: false),
                        Korisnik_Id = c.Int(),
                        Wishlist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Korisnik_Id)
                .ForeignKey("dbo.Wishlists", t => t.Wishlist_Id)
                .Index(t => t.Korisnik_Id)
                .Index(t => t.Wishlist_Id);
            
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Korisnik_Name = c.String(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Image = c.String(),
                        Age = c.Int(nullable: false),
                        Korisnik_Wishlist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wishlists", t => t.Korisnik_Wishlist_Id)
                .Index(t => t.Korisnik_Wishlist_Id);
            
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wishlist_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Korisniks", "Korisnik_Wishlist_Id", "dbo.Wishlists");
            DropForeignKey("dbo.Games", "Wishlist_Id", "dbo.Wishlists");
            DropForeignKey("dbo.Games", "Korisnik_Id", "dbo.Korisniks");
            DropIndex("dbo.Korisniks", new[] { "Korisnik_Wishlist_Id" });
            DropIndex("dbo.Games", new[] { "Wishlist_Id" });
            DropIndex("dbo.Games", new[] { "Korisnik_Id" });
            DropTable("dbo.Wishlists");
            DropTable("dbo.Korisniks");
            DropTable("dbo.Games");
        }
    }
}
