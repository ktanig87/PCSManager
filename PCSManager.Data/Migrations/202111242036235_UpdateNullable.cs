namespace PCSManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Boxes", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Boxes", new[] { "RoomId" });
            AlterColumn("dbo.Boxes", "RoomId", c => c.Int());
            CreateIndex("dbo.Boxes", "RoomId");
            AddForeignKey("dbo.Boxes", "RoomId", "dbo.Rooms", "RoomId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boxes", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Boxes", new[] { "RoomId" });
            AlterColumn("dbo.Boxes", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Boxes", "RoomId");
            AddForeignKey("dbo.Boxes", "RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
        }
    }
}
