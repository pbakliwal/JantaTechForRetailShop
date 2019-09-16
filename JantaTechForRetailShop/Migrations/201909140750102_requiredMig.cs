namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Category", c => c.String());
            AlterColumn("dbo.Products", "Colour", c => c.String());
            AlterColumn("dbo.Products", "Size", c => c.String());
            AlterColumn("dbo.Products", "Brand", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Brand", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Size", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Colour", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Category", c => c.String(nullable: false));
        }
    }
}
