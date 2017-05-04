namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class backtowhereIstartedbeginningofdaywithclassesintherightspotandgoogleapikeyadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        CountryName = c.String(),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        CountryCode = c.String(),
                        MapReference = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        MapReference = c.String(),
                        CountryCode = c.String(),
                        CountryCodeLong = c.String(),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Countries", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Countries", new[] { "Location_Id" });
            DropTable("dbo.Countries");
            DropTable("dbo.Locations");
        }
    }
}
