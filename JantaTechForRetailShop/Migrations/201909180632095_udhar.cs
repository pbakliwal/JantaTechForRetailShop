namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udhar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Billings", "AmountPaid", c => c.Int(nullable: false));
            DropColumn("dbo.Billings", "IsPaid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Billings", "IsPaid", c => c.Boolean(nullable: false));
            DropColumn("dbo.Billings", "AmountPaid");
        }
    }
}
