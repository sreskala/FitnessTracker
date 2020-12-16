using FitnessTracker.Data;
using FitnessTracker.Data.Goals;
using FitnessTracker.Models.GoalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services.GoalServices
{
    public class GoalService
    {
        //initialize private field
        private readonly Guid _userId;

        public GoalService(Guid userId)
        {
            _userId = userId;
        }

        //GET ALL Goals for a user
        public IEnumerable<GoalListItem> GetAllGoals()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Goals
                    .Where(g => g.OwnerId == _userId)
                    .Select(
                        g =>
                        new GoalListItem()
                        {
                            GoalId = g.GoalId,
                            Title = g.Title,
                            DateCreatedUtc = g.DateCreatedUtc,
                            Completed = g.Completed
                        }
                        );
                return query.ToArray();
            }
        }

        //GET GOAL BY ID
        public GoalDetail GetGoalById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Goals
                    .Single(g => g.GoalId == id && g.OwnerId == _userId);

                return new GoalDetail()
                {
                    GoalId = entity.GoalId,
                    Title = entity.Title,
                    Description = entity.Description,
                    DateCreatedUtc = entity.DateCreatedUtc,
                    DateModifiedUtc = entity.DateModifiedUtc,
                    Completed = entity.Completed
                };
            }
        }

        //CREATE NEW GOAL
        public bool CreateGoal(GoalCreate model)
        {
            var entity =
                new Goal()
                {
                    Title = model.Title,
                    Description = model.Description,
                    DateCreatedUtc = DateTimeOffset.Now,
                    Completed = false,
                    OwnerId = _userId
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Goals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //EDIT GOAL
        public bool UpdateGoal(GoalEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Goals
                    .Single(g => g.GoalId == model.GoalId && g.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.DateModifiedUtc = DateTimeOffset.Now;
                entity.Completed = model.Completed;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE GOAL
        public bool DeleteGoal(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Goals
                    .Single(g => g.GoalId == id && g.OwnerId == _userId);

                ctx.Goals.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
