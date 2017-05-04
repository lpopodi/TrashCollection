namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Locations", "ServiceID", c => c.String());
            AddColumn("dbo.Services", "CustomerID", c => c.String());
            DropColumn("dbo.Services", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Services", "CustomerID");
            DropColumn("dbo.Locations", "ServiceID");
            DropTable("dbo.Customers");
        }
    }
}
