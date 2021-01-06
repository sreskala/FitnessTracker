using FitnessTracker.Data;
using FitnessTracker.Models;
using FitnessTracker.Models.MealModels.Meal;
using FitnessTracker.Models.MealModels.MealPlan;
using FitnessTracker.Models.WorkoutModels.WorkoutPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services.UserServices
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public PlanMergeMealWorkout GetLatestMealAndWorkoutPlan()
        {
            using(var ctx = new ApplicationDbContext())
            {
               
                var meal =
                    ctx.MealPlans.Count() < 0 ? null :
                    ctx
                    .MealPlans
                    .Where(m => m.OwnerId == _userId)
                    .OrderByDescending(m => m.MealPlanId)
                    .FirstOrDefault();

                var workout = 
                    ctx.WorkoutPlans.Count() < 1 ? null :
                    ctx
                    .WorkoutPlans
                    .Where(w => w.OwnerId == _userId)
                    .OrderByDescending(w => w.WorkoutPlanId)
                    .FirstOrDefault();

                var mergedItems =
                    new PlanMergeMealWorkout
                    {
                        MealPlan = meal == null ? null : new MealPlanListItem
                        {
                            MealPlanId = meal.MealPlanId,
                            Title = meal.Title,
                            DateCreatedUtc = meal.DateCreatedUtc
                        },
                        WorkoutPlan = workout == null ? null : new WorkoutPlanListItem
                        {
                            WorkoutPlanId = workout.WorkoutPlanId,
                            Title = workout.Title,
                            DateCreatedUtc = workout.DateCreatedUtc
                        }
                    };

                return mergedItems;

            }
        }
    }
}
