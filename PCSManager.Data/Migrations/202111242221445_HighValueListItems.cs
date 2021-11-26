namespace PCSManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HighValueListItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DamageClaims", "ClaimResolved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DamageClaims", "ClaimResolved");
        }
    }
}
