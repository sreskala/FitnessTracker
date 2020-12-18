using FitnessTracker.Data;
using FitnessTracker.Data.WorkoutData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services.WorkoutServices
{
    public class WorkoutForWorkoutPlanService
    {
        private readonly Guid _userId;

        public WorkoutForWorkoutPlanService(Guid userId)
        {
            _userId = userId;
        }

        //Create all workouts for each workout plan
        public bool CreateWorkoutsForWorkoutPlans()
        {
            using(var ctx = new ApplicationDbContext())
            {
                List<int> currentWorkoutsForWorkoutPlan = new List<int>();

                bool add = true;

                foreach(WorkoutForWorkoutPlan current in ctx.WorkoutForWorkoutPlans)
                {
                    currentWorkoutsForWorkoutPlan.Add(current.WorkoutId);
                }

                foreach(Workout workout in ctx.Workouts)
                {
                    foreach(int exId in currentWorkoutsForWorkoutPlan)
                    {
                        if(exId == workout.WorkoutId)
                        {
                            add = false;
                            break;
                        }
                    }

                    if (add)
                    {
                        var workoutForWorkoutPlan =
                            new WorkoutForWorkoutPlan()
                            {
                                WorkoutPlanId = workout.WorkoutPlanId,
                                WorkoutId = workout.WorkoutId
                            };

                        ctx.WorkoutForWorkoutPlans.Add(workoutForWorkoutPlan);
                    }

                    add = true;
                }

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
