namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wishlistupdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "Store_Id", c => c.Int());
            CreateIndex("dbo.Games", "Store_Id");
            AddForeignKey("dbo.Games", "Store_Id", "dbo.Stores", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Store_Id", "dbo.Stores");
            DropIndex("dbo.Games", new[] { "Store_Id" });
            DropColumn("dbo.Games", "Store_Id");
            DropTable("dbo.Stores");
        }
    }
}
