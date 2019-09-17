namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredBar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TempProducts", "BarCodeId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TempProducts", "BarCodeId", c => c.String());
        }
    }
}
