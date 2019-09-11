namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredM : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "BarCodeId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "BarCodeId", c => c.String());
        }
    }
}
