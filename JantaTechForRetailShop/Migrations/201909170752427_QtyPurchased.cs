namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QtyPurchased : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TempProducts", "QtyPurchased", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TempProducts", "QtyPurchased");
        }
    }
}
