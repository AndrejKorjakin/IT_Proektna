namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registerloginupdated : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserAccounts", newName: "Korisniks");
            RenameColumn(table: "dbo.Games", name: "UserAccount_Id", newName: "Korisnik_Id");
            RenameIndex(table: "dbo.Games", name: "IX_UserAccount_Id", newName: "IX_Korisnik_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Games", name: "IX_Korisnik_Id", newName: "IX_UserAccount_Id");
            RenameColumn(table: "dbo.Games", name: "Korisnik_Id", newName: "UserAccount_Id");
            RenameTable(name: "dbo.Korisniks", newName: "UserAccounts");
        }
    }
}
