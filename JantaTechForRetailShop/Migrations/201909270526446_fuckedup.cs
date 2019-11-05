namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuckedup : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Billings", "AmountDue");
            DropColumn("dbo.Customers", "AmountDue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "AmountDue", c => c.Int(nullable: false));
            AddColumn("dbo.Billings", "AmountDue", c => c.Int(nullable: false));
        }
    }
}
