namespace Trash_Collection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcontrollerforservices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        OneTimeChange = c.Boolean(nullable: false),
                        TempChangeDay = c.String(),
                        PermanentChange = c.Boolean(nullable: false),
                        ServiceDay = c.String(),
                        ServiceHold = c.Boolean(nullable: false),
                        HoldDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Services");
        }
    }
}
