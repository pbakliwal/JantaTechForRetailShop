namespace JantaTechForRetailShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class daa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodayExpenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TodayExpence = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TodayExpenses");
        }
    }
}
