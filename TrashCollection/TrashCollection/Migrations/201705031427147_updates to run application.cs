namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestorunapplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "ServiceHold", c => c.Boolean(nullable: false));
            AddColumn("dbo.Services", "HoldDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Services", "Hold");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Hold", c => c.DateTime(nullable: false));
            DropColumn("dbo.Services", "HoldDate");
            DropColumn("dbo.Services", "ServiceHold");
        }
    }
}
