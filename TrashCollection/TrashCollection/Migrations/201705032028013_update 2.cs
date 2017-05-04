namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Countries", "Location_LocationId", "dbo.Locations");
            RenameColumn(table: "dbo.Countries", name: "Location_LocationId", newName: "Location_Id");
            RenameIndex(table: "dbo.Countries", name: "IX_Location_LocationId", newName: "IX_Location_Id");
            DropPrimaryKey("dbo.Locations");
            AddColumn("dbo.Locations", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Locations", "Id");
            AddForeignKey("dbo.Countries", "Location_Id", "dbo.Locations", "Id");
            DropColumn("dbo.Locations", "LocationId");
            DropColumn("dbo.Locations", "ServiceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "ServiceID", c => c.String());
            AddColumn("dbo.Locations", "LocationId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Countries", "Location_Id", "dbo.Locations");
            DropPrimaryKey("dbo.Locations");
            DropColumn("dbo.Locations", "Id");
            AddPrimaryKey("dbo.Locations", "LocationId");
            RenameIndex(table: "dbo.Countries", name: "IX_Location_Id", newName: "IX_Location_LocationId");
            RenameColumn(table: "dbo.Countries", name: "Location_Id", newName: "Location_LocationId");
            AddForeignKey("dbo.Countries", "Location_LocationId", "dbo.Locations", "LocationId");
        }
    }
}
