namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingSelling : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SellingHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillingId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Billings", t => t.BillingId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.BillingId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellingHistories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SellingHistories", "BillingId", "dbo.Billings");
            DropIndex("dbo.SellingHistories", new[] { "ProductId" });
            DropIndex("dbo.SellingHistories", new[] { "BillingId" });
            DropTable("dbo.SellingHistories");
        }
    }
}
