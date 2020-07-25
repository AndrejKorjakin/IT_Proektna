namespace BundleGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registerwithuseradded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
