namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addexercisejoin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodItemForMeal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MealId = c.Int(nullable: false),
                        FoodItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodItem", t => t.FoodItemId)
                .ForeignKey("dbo.Meal", t => t.MealId)
                .Index(t => t.MealId)
                .Index(t => t.FoodItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodItemForMeal", "MealId", "dbo.Meal");
            DropForeignKey("dbo.FoodItemForMeal", "FoodItemId", "dbo.FoodItem");
            DropIndex("dbo.FoodItemForMeal", new[] { "FoodItemId" });
            DropIndex("dbo.FoodItemForMeal", new[] { "MealId" });
            DropTable("dbo.FoodItemForMeal");
        }
    }
}
