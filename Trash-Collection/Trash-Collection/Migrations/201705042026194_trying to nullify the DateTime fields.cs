namespace Trash_Collection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingtonullifytheDateTimefields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "TempChangeDay", c => c.DateTime());
            AlterColumn("dbo.Services", "HoldDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "HoldDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Services", "TempChangeDay", c => c.String());
        }
    }
}
