namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revertimageupload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Korisniks", "Image", c => c.String());
            DropColumn("dbo.Korisniks", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Korisniks", "ImagePath", c => c.String());
            DropColumn("dbo.Korisniks", "Image");
        }
    }
}
