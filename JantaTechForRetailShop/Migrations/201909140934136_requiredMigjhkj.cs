namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredMigjhkj : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Colour", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Size", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Brand", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Brand", c => c.String());
            AlterColumn("dbo.Products", "Size", c => c.String());
            AlterColumn("dbo.Products", "Colour", c => c.String());
            AlterColumn("dbo.Products", "Category", c => c.String());
        }
    }
}
