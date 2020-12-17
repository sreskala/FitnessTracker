namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MealForMealPlan", "MealId", "dbo.Meal");
            DropForeignKey("dbo.MealForMealPlan", "MealPlanId", "dbo.MealPlan");
            DropForeignKey("dbo.Meal", "MealPlanId", "dbo.MealPlan");
            AddForeignKey("dbo.MealForMealPlan", "MealId", "dbo.Meal", "MealId");
            AddForeignKey("dbo.MealForMealPlan", "MealPlanId", "dbo.MealPlan", "MealPlanId");
            AddForeignKey("dbo.Meal", "MealPlanId", "dbo.MealPlan", "MealPlanId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meal", "MealPlanId", "dbo.MealPlan");
            DropForeignKey("dbo.MealForMealPlan", "MealPlanId", "dbo.MealPlan");
            DropForeignKey("dbo.MealForMealPlan", "MealId", "dbo.Meal");
            AddForeignKey("dbo.Meal", "MealPlanId", "dbo.MealPlan", "MealPlanId", cascadeDelete: true);
            AddForeignKey("dbo.MealForMealPlan", "MealPlanId", "dbo.MealPlan", "MealPlanId", cascadeDelete: true);
            AddForeignKey("dbo.MealForMealPlan", "MealId", "dbo.Meal", "MealId", cascadeDelete: true);
        }
    }
}
