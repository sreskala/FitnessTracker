namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedGoals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goal",
                c => new
                    {
                        GoalId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        DateCreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        DateModifiedUtc = c.DateTimeOffset(precision: 7),
                        Completed = c.Boolean(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.GoalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Goal");
        }
    }
}
