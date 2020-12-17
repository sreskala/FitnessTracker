namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MealForMealPlan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MealPlanId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MealPlan", t => t.MealPlanId, cascadeDelete: true)
                .ForeignKey("dbo.Meal", t => t.MealId, cascadeDelete: true)
                .Index(t => t.MealPlanId)
                .Index(t => t.MealId);
            
            AddColumn("dbo.Meal", "MealPlanId", c => c.Int(nullable: false));
            AlterColumn("dbo.Meal", "Title", c => c.String(nullable: false));
            CreateIndex("dbo.Meal", "MealPlanId");
            AddForeignKey("dbo.Meal", "MealPlanId", "dbo.MealPlan", "MealPlanId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealForMealPlan", "MealId", "dbo.Meal");
            DropForeignKey("dbo.Meal", "MealPlanId", "dbo.MealPlan");
            DropForeignKey("dbo.MealForMealPlan", "MealPlanId", "dbo.MealPlan");
            DropIndex("dbo.Meal", new[] { "MealPlanId" });
            DropIndex("dbo.MealForMealPlan", new[] { "MealId" });
            DropIndex("dbo.MealForMealPlan", new[] { "MealPlanId" });
            AlterColumn("dbo.Meal", "Title", c => c.String());
            DropColumn("dbo.Meal", "MealPlanId");
            DropTable("dbo.MealForMealPlan");
        }
    }
}
