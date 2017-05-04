namespace Trash_Collection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationtoinvoiceforkeyforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "Service_ServiceId", "dbo.Services");
            DropIndex("dbo.Invoices", new[] { "Service_ServiceId" });
            RenameColumn(table: "dbo.Invoices", name: "Service_ServiceId", newName: "ServiceId");
            AlterColumn("dbo.Invoices", "ServiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoices", "ServiceId");
            AddForeignKey("dbo.Invoices", "ServiceId", "dbo.Services", "ServiceId", cascadeDelete: true);
            DropColumn("dbo.Invoices", "SrvId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "SrvId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Invoices", "ServiceId", "dbo.Services");
            DropIndex("dbo.Invoices", new[] { "ServiceId" });
            AlterColumn("dbo.Invoices", "ServiceId", c => c.Int());
            RenameColumn(table: "dbo.Invoices", name: "ServiceId", newName: "Service_ServiceId");
            CreateIndex("dbo.Invoices", "Service_ServiceId");
            AddForeignKey("dbo.Invoices", "Service_ServiceId", "dbo.Services", "ServiceId");
        }
    }
}
