namespace Trash_Collection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingtotiedatasetstogether : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Countries", "Pickup_PickupId", "dbo.Pickups");
            DropPrimaryKey("dbo.Pickups");
            AddColumn("dbo.Invoices", "SrvId", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "Service_ServiceId", c => c.Int());
            AddColumn("dbo.Services", "UserId", c => c.String());
            AddColumn("dbo.Services", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Pickups", "PickupId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Pickups", "PickupId");
            CreateIndex("dbo.Invoices", "Service_ServiceId");
            CreateIndex("dbo.Services", "ApplicationUser_Id");
            CreateIndex("dbo.Pickups", "PickupId");
            AddForeignKey("dbo.Services", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Invoices", "Service_ServiceId", "dbo.Services", "ServiceId");
            AddForeignKey("dbo.Pickups", "PickupId", "dbo.Services", "ServiceId");
            AddForeignKey("dbo.Countries", "Pickup_PickupId", "dbo.Pickups", "PickupId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Countries", "Pickup_PickupId", "dbo.Pickups");
            DropForeignKey("dbo.Pickups", "PickupId", "dbo.Services");
            DropForeignKey("dbo.Invoices", "Service_ServiceId", "dbo.Services");
            DropForeignKey("dbo.Services", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Pickups", new[] { "PickupId" });
            DropIndex("dbo.Services", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Invoices", new[] { "Service_ServiceId" });
            DropPrimaryKey("dbo.Pickups");
            AlterColumn("dbo.Pickups", "PickupId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Services", "ApplicationUser_Id");
            DropColumn("dbo.Services", "UserId");
            DropColumn("dbo.Invoices", "Service_ServiceId");
            DropColumn("dbo.Invoices", "SrvId");
            AddPrimaryKey("dbo.Pickups", "PickupId");
            AddForeignKey("dbo.Countries", "Pickup_PickupId", "dbo.Pickups", "PickupId");
        }
    }
}
