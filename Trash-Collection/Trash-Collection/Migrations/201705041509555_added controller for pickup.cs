namespace Trash_Collection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcontrollerforpickup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pickups",
                c => new
                    {
                        PickupId = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        CountryCode = c.String(),
                        MapReference = c.String(),
                    })
                .PrimaryKey(t => t.PickupId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        MapReference = c.String(),
                        CountryCode = c.String(),
                        CountryCodeLong = c.String(),
                        Pickup_PickupId = c.Int(),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.Pickups", t => t.Pickup_PickupId)
                .Index(t => t.Pickup_PickupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Countries", "Pickup_PickupId", "dbo.Pickups");
            DropIndex("dbo.Countries", new[] { "Pickup_PickupId" });
            DropTable("dbo.Countries");
            DropTable("dbo.Pickups");
        }
    }
}
