namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class details : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodayExpenses", "Details", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodayExpenses", "Details");
        }
    }
}
