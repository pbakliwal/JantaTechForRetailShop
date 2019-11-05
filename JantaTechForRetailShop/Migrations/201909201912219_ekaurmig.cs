namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ekaurmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CostPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "CostPrice");
        }
    }
}
