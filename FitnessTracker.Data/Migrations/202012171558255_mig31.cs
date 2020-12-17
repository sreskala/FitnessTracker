namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meal",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.MealId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Meal");
        }
    }
}
