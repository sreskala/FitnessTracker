using FitnessTracker.Data;
using FitnessTracker.Data.WorkoutData;
using FitnessTracker.Models.MealModels.JoiningTableModels;
using FitnessTracker.Models.WorkoutModels.WorkoutModels;
using FitnessTracker.Models.WorkoutModels.WorkoutPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services.WorkoutServices
{
    public class WorkoutPlanService
    {
        //field
        private readonly Guid _userId;

        public WorkoutPlanService(Guid userId)
        {
            _userId = userId;
        }

        //GET ALL WORKOUT PLANS FOR USER
        public IEnumerable<WorkoutPlanListItem> GetWorkoutPlans()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .WorkoutPlans
                    .Where(w => w.OwnerId == _userId)
                    .Select( w =>
                        new WorkoutPlanListItem()
                        {
                            WorkoutPlanId = w.WorkoutPlanId,
                            Title = w.Title,
                            DateCreatedUtc = w.DateCreatedUtc
                        });

                return query.ToArray();
            }
        }

        //CREATE A NEW WORKOUT PLAN
        public bool CreateNewWorkoutPlan(WorkoutPlanCreate model)
        {
            var entity =
                new WorkoutPlan()
                {
                    Title = model.Title,
                    DateCreatedUtc = DateTimeOffset.Now,
                    OwnerId = _userId
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.WorkoutPlans.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //GET WORKOUT PLAN BY ID
        public WorkoutPlanDetail GetWorkoutById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .WorkoutPlans
                    .Single(w => w.WorkoutPlanId == id && w.OwnerId == _userId);

                return new WorkoutPlanDetail
                {
                    WorkoutPlanId = entity.WorkoutPlanId,
                    Title = entity.Title,
                    DateCreatedUtc = entity.DateCreatedUtc,
                    DateModifiedUtc = entity.DateModifiedUtc,
                    Workouts =
                        ctx.WorkoutForWorkoutPlans
                        .Where(wp => wp.WorkoutPlanId == entity.WorkoutPlanId)
                        .Select(
                            wp =>
                            new WorkoutForWorkoutPlanListItem
                            {
                                Id = wp.Id,
                                WorkoutPlanId = wp.WorkoutPlanId,
                                WorkoutId = wp.WorkoutId,
                                Workout = new WorkoutListItem
                                {
                                    WorkoutId = wp.WorkoutId,
                                    Title = wp.Workout.Title
                                }
                            }
                            ).ToList()
                };
            }
        }

        //EDIT WORKOUT PLAN BY ID
        public bool UpdateWorkoutPlan(WorkoutPlanUpdate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .WorkoutPlans
                    .Single(w => w.WorkoutPlanId == model.WorkoutPlanId && w.OwnerId == _userId);

                entity.Title = model.Title;
                entity.DateModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete workoutplan
        public bool DeleteWorkoutPlan(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .WorkoutPlans
                    .Single(w => w.WorkoutPlanId == id && w.OwnerId == _userId);

                ctx.WorkoutPlans.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
