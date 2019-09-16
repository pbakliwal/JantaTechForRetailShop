namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingTempTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TempProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        BarCodeId = c.String(),
                        Colour = c.String(),
                        Price = c.Int(nullable: false),
                        Size = c.String(),
                        Quantity = c.Int(nullable: false),
                        Brand = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TempProducts");
        }
    }
}
