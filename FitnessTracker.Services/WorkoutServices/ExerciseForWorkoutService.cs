using FitnessTracker.Data;
using FitnessTracker.Data.WorkoutData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services.WorkoutServices
{
    public class ExerciseForWorkoutService
    {
        //private field
        private readonly Guid _userId;

        public ExerciseForWorkoutService(Guid userId)
        {
            _userId = userId;
        }

        //Create all exercises for respective Workouts
        public bool CreateExercisesForWorkouts()
        {
            using(var ctx = new ApplicationDbContext())
            {
                List<int> currentExercisesforWorkouts = new List<int>();
                bool add = true;

                foreach(ExerciseForWorkout current in ctx.ExerciseForWorkouts)
                {
                    currentExercisesforWorkouts.Add(current.ExerciseId);
                }

                foreach(Exercise exercise in ctx.Exercises)
                {
                    foreach(int exId in currentExercisesforWorkouts)
                    {
                        if (exId == exercise.ExerciseId)
                        {
                            add = false;
                            break;
                        }
                        
                    }

                    if (add)
                    {
                        var exerciseForWorkout =
                            new ExerciseForWorkout()
                            {
                                WorkoutId = exercise.WorkoutId,
                                ExerciseId = exercise.ExerciseId
                            };

                        ctx.ExerciseForWorkouts.Add(exerciseForWorkout);
                    }

                    add = true;
                }

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
