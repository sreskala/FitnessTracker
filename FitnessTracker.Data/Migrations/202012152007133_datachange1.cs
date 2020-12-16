namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datachange1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MealPlan", "Week");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MealPlan", "Week", c => c.Int(nullable: false));
        }
    }
}
