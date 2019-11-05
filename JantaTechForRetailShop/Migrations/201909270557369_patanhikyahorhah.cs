namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patanhikyahorhah : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Billings", "AmountDue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Billings", "AmountDue");
        }
    }
}
