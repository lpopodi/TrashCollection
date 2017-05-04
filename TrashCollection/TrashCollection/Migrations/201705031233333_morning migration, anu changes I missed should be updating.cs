namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morningmigrationanuchangesImissedshouldbeupdating : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Locations");
            AddColumn("dbo.Locations", "NickName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Locations", "NickName");
            DropColumn("dbo.Locations", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Name", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Locations");
            DropColumn("dbo.Locations", "NickName");
            AddPrimaryKey("dbo.Locations", "Name");
        }
    }
}
