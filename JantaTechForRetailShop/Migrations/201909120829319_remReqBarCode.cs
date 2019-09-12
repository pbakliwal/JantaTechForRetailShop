namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remReqBarCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "BarCodeId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "BarCodeId", c => c.String(nullable: false));
        }
    }
}
