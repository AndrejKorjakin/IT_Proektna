namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myloginandregisteradded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Korisniks", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Korisniks", "Email", c => c.String(nullable: true));
            AlterColumn("dbo.Korisniks", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Korisniks", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Korisniks", "Password", c => c.String());
            AlterColumn("dbo.Korisniks", "Username", c => c.String());
            AlterColumn("dbo.Korisniks", "Email", c => c.String());
            DropColumn("dbo.Korisniks", "ConfirmPassword");
        }
    }
}
