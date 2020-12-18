namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkoutForWorkoutPlan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkoutPlanId = c.Int(nullable: false),
                        WorkoutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workout", t => t.WorkoutId)
                .ForeignKey("dbo.WorkoutPlan", t => t.WorkoutPlanId)
                .Index(t => t.WorkoutPlanId)
                .Index(t => t.WorkoutId);
            
            CreateTable(
                "dbo.Workout",
                c => new
                    {
                        WorkoutId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        WorkoutPlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkoutId)
                .ForeignKey("dbo.WorkoutPlan", t => t.WorkoutPlanId)
                .Index(t => t.WorkoutPlanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkoutForWorkoutPlan", "WorkoutPlanId", "dbo.WorkoutPlan");
            DropForeignKey("dbo.WorkoutForWorkoutPlan", "WorkoutId", "dbo.Workout");
            DropForeignKey("dbo.Workout", "WorkoutPlanId", "dbo.WorkoutPlan");
            DropIndex("dbo.Workout", new[] { "WorkoutPlanId" });
            DropIndex("dbo.WorkoutForWorkoutPlan", new[] { "WorkoutId" });
            DropIndex("dbo.WorkoutForWorkoutPlan", new[] { "WorkoutPlanId" });
            DropTable("dbo.Workout");
            DropTable("dbo.WorkoutForWorkoutPlan");
        }
    }
}
