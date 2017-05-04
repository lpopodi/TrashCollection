namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classmodificationsworkingonbinding : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            AddColumn("dbo.Customers", "CustomerId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Customers", "Day", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ServiceHold", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "HoldDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "LocationId", c => c.String());
            AddColumn("dbo.Customers", "BillingId", c => c.String());
            DropColumn("dbo.Customers", "Id");
            DropColumn("dbo.Customers", "Price");
            AddPrimaryKey("dbo.Customers", "CustomerId");
            DropTable("dbo.Services");
            CreateTable(
                "dbo.Billings",
                c => new
                    {
                        BillingId = c.String(nullable: false, maxLength: 128),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BillingId);
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.String(nullable: false),
                        ServiceHold = c.Boolean(nullable: false),
                        HoldDate = c.DateTime(nullable: false),
                        CustomerID = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Locations", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Customers", "Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Countries", "Location_LocationId", "dbo.Locations");
            DropPrimaryKey("dbo.Locations");
            DropPrimaryKey("dbo.Customers");
            DropColumn("dbo.Locations", "LocationId");
            DropColumn("dbo.Customers", "BillingId");
            DropColumn("dbo.Customers", "LocationId");
            DropColumn("dbo.Customers", "HoldDate");
            DropColumn("dbo.Customers", "ServiceHold");
            DropColumn("dbo.Customers", "Day");
            DropColumn("dbo.Customers", "CustomerId");
            DropTable("dbo.Billings");
            AddPrimaryKey("dbo.Locations", "Id");
            AddPrimaryKey("dbo.Customers", "Id");
            RenameIndex(table: "dbo.Countries", name: "IX_Location_LocationId", newName: "IX_Location_Id");
            RenameColumn(table: "dbo.Countries", name: "Location_LocationId", newName: "Location_Id");
            AddForeignKey("dbo.Countries", "Location_Id", "dbo.Locations", "Id");
        }
    }
}
