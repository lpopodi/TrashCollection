namespace Trash_Collection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messingwithcodeforgoogleapi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pickups", "CountryName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pickups", "CountryName");
        }
    }
}
