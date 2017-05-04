namespace Trash_Collection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyingPickupoptionsandcreation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Countries", "Pickup_PickupId", "dbo.Pickups");
            DropIndex("dbo.Countries", new[] { "Pickup_PickupId" });
            DropColumn("dbo.Pickups", "CountryName");
            DropColumn("dbo.Pickups", "CountryCode");
            DropColumn("dbo.Pickups", "MapReference");
            DropTable("dbo.Countries");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.CountryId);
            
            AddColumn("dbo.Pickups", "MapReference", c => c.String());
            AddColumn("dbo.Pickups", "CountryCode", c => c.String());
            AddColumn("dbo.Pickups", "CountryName", c => c.String());
            CreateIndex("dbo.Countries", "Pickup_PickupId");
            AddForeignKey("dbo.Countries", "Pickup_PickupId", "dbo.Pickups", "PickupId");
        }
    }
}
