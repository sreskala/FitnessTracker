namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFoodItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodItem",
                c => new
                    {
                        FoodItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Quantity = c.Int(nullable: false),
                        Calories = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        MealId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodItemId)
                .ForeignKey("dbo.Meal", t => t.MealId)
                .Index(t => t.MealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodItem", "MealId", "dbo.Meal");
            DropIndex("dbo.FoodItem", new[] { "MealId" });
            DropTable("dbo.FoodItem");
        }
    }
}
