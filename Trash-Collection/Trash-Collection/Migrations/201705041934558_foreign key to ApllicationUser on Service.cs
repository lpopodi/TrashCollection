namespace Trash_Collection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeytoApllicationUseronService : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Services", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Services", "UserId");
            RenameColumn(table: "dbo.Services", name: "ApplicationUser_Id", newName: "UserId");
            AlterColumn("dbo.Services", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Services", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Services", new[] { "UserId" });
            AlterColumn("dbo.Services", "UserId", c => c.String());
            RenameColumn(table: "dbo.Services", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Services", "UserId", c => c.String());
            CreateIndex("dbo.Services", "ApplicationUser_Id");
        }
    }
}
