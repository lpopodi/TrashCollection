namespace Trash_Collection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingdatetimedatatypestofields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "ServiceDay", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "ServiceDay", c => c.String());
        }
    }
}
