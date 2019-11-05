namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class amountdueincustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AmountDue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "AmountDue");
        }
    }
}
