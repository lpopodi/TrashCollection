namespace Trash_Collection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingtofixpickupstable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pickups", "PickupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pickups", "PickupId", c => c.Int(nullable: false));
        }
    }
}
