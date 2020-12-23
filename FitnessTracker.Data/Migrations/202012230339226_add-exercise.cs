namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addexercise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercise",
                c => new
                    {
                        ExerciseId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Repetition = c.Int(nullable: false),
                        Sets = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Muscle = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        WorkoutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExerciseId)
                .ForeignKey("dbo.Workout", t => t.WorkoutId)
                .Index(t => t.WorkoutId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercise", "WorkoutId", "dbo.Workout");
            DropIndex("dbo.Exercise", new[] { "WorkoutId" });
            DropTable("dbo.Exercise");
        }
    }
}
