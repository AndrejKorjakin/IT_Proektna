namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletefromcartchanged1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AddGameToCardModels", newName: "GamesInShoppingCarts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.GamesInShoppingCarts", newName: "AddGameToCardModels");
        }
    }
}
