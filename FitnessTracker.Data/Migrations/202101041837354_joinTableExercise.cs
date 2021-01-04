namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class joinTableExercise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExerciseForWorkout",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkoutId = c.Int(nullable: false),
                        ExerciseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercise", t => t.ExerciseId)
                .ForeignKey("dbo.Workout", t => t.WorkoutId)
                .Index(t => t.WorkoutId)
                .Index(t => t.ExerciseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExerciseForWorkout", "WorkoutId", "dbo.Workout");
            DropForeignKey("dbo.ExerciseForWorkout", "ExerciseId", "dbo.Exercise");
            DropIndex("dbo.ExerciseForWorkout", new[] { "ExerciseId" });
            DropIndex("dbo.ExerciseForWorkout", new[] { "WorkoutId" });
            DropTable("dbo.ExerciseForWorkout");
        }
    }
}
