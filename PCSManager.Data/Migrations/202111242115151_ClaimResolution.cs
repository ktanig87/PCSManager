namespace PCSManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClaimResolution : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DamageClaims", "ClaimResolved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DamageClaims", "ClaimResolved", c => c.Boolean(nullable: false));
        }
    }
}
