namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkoutPlan",
                c => new
                    {
                        WorkoutPlanId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        DateCreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        DateModifiedUtc = c.DateTimeOffset(precision: 7),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.WorkoutPlanId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkoutPlan");
        }
    }
}
