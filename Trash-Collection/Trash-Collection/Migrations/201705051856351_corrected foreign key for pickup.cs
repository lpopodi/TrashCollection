namespace Trash_Collection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctedforeignkeyforpickup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pickups", "PickupId", "dbo.Services");
            DropIndex("dbo.Pickups", new[] { "PickupId" });
            DropPrimaryKey("dbo.Pickups");
            AddColumn("dbo.Pickups", "ServiceId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Pickups", "ServiceId");
            CreateIndex("dbo.Pickups", "ServiceId");
            AddForeignKey("dbo.Pickups", "ServiceId", "dbo.Services", "ServiceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pickups", "ServiceId", "dbo.Services");
            DropIndex("dbo.Pickups", new[] { "ServiceId" });
            DropPrimaryKey("dbo.Pickups");
            DropColumn("dbo.Pickups", "ServiceId");
            AddPrimaryKey("dbo.Pickups", "PickupId");
            CreateIndex("dbo.Pickups", "PickupId");
            AddForeignKey("dbo.Pickups", "PickupId", "dbo.Services", "ServiceId");
        }
    }
}
