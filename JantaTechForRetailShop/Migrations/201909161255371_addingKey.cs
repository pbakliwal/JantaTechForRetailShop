namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SellingHistories", "ProductId", "dbo.Products");
            DropIndex("dbo.SellingHistories", new[] { "ProductId" });
            DropPrimaryKey("dbo.Products");
            AddColumn("dbo.SellingHistories", "Product_BarCodeId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "BarCodeId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Products", "BarCodeId");
            CreateIndex("dbo.SellingHistories", "Product_BarCodeId");
            AddForeignKey("dbo.SellingHistories", "Product_BarCodeId", "dbo.Products", "BarCodeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellingHistories", "Product_BarCodeId", "dbo.Products");
            DropIndex("dbo.SellingHistories", new[] { "Product_BarCodeId" });
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "BarCodeId", c => c.String());
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.SellingHistories", "Product_BarCodeId");
            AddPrimaryKey("dbo.Products", "Id");
            CreateIndex("dbo.SellingHistories", "ProductId");
            AddForeignKey("dbo.SellingHistories", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
