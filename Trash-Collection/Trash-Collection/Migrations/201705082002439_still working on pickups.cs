namespace Trash_Collection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stillworkingonpickups : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pickups", "Latitude");
            DropColumn("dbo.Pickups", "Longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pickups", "Longitude", c => c.Single(nullable: false));
            AddColumn("dbo.Pickups", "Latitude", c => c.Single(nullable: false));
        }
    }
}
