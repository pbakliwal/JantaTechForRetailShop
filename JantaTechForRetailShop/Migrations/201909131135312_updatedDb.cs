namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Billings", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Billings", "IsPaid", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Billings", "CustomerId");
            AddForeignKey("dbo.Billings", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Billings", "PhoneNo");
            DropColumn("dbo.Billings", "CustomerName");
            DropColumn("dbo.Billings", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Billings", "TotalAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Billings", "CustomerName", c => c.String());
            AddColumn("dbo.Billings", "PhoneNo", c => c.String(nullable: false));
            DropForeignKey("dbo.Billings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Billings", new[] { "CustomerId" });
            DropColumn("dbo.Billings", "IsPaid");
            DropColumn("dbo.Billings", "CustomerId");
        }
    }
}
