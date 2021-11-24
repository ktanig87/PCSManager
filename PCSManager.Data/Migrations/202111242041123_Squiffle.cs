namespace PCSManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Squiffle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Boxes", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.InventoryItems", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Boxes", new[] { "RoomId" });
            DropIndex("dbo.InventoryItems", new[] { "RoomId" });
            AlterColumn("dbo.Boxes", "RoomId", c => c.Int(nullable: false));
            AlterColumn("dbo.InventoryItems", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Boxes", "RoomId");
            CreateIndex("dbo.InventoryItems", "RoomId");
            AddForeignKey("dbo.Boxes", "RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
            AddForeignKey("dbo.InventoryItems", "RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryItems", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Boxes", "RoomId", "dbo.Rooms");
            DropIndex("dbo.InventoryItems", new[] { "RoomId" });
            DropIndex("dbo.Boxes", new[] { "RoomId" });
            AlterColumn("dbo.InventoryItems", "RoomId", c => c.Int());
            AlterColumn("dbo.Boxes", "RoomId", c => c.Int());
            CreateIndex("dbo.InventoryItems", "RoomId");
            CreateIndex("dbo.Boxes", "RoomId");
            AddForeignKey("dbo.InventoryItems", "RoomId", "dbo.Rooms", "RoomId");
            AddForeignKey("dbo.Boxes", "RoomId", "dbo.Rooms", "RoomId");
        }
    }
}
