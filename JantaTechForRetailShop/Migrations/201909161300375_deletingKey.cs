namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletingKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SellingHistories", "Product_BarCodeId", "dbo.Products");
            DropIndex("dbo.SellingHistories", new[] { "Product_BarCodeId" });
            DropColumn("dbo.SellingHistories", "ProductId");
            RenameColumn(table: "dbo.SellingHistories", name: "Product_BarCodeId", newName: "ProductId");
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "BarCodeId", c => c.String());
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.SellingHistories", "ProductId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Products", "Id");
            CreateIndex("dbo.SellingHistories", "ProductId");
            AddForeignKey("dbo.SellingHistories", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellingHistories", "ProductId", "dbo.Products");
            DropIndex("dbo.SellingHistories", new[] { "ProductId" });
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.SellingHistories", "ProductId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "BarCodeId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Products", "BarCodeId");
            RenameColumn(table: "dbo.SellingHistories", name: "ProductId", newName: "Product_BarCodeId");
            AddColumn("dbo.SellingHistories", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.SellingHistories", "Product_BarCodeId");
            AddForeignKey("dbo.SellingHistories", "Product_BarCodeId", "dbo.Products", "BarCodeId");
        }
    }
}
