﻿using FitnessTracker.Data;
using FitnessTracker.Data.WorkoutData;
using FitnessTracker.Models.MealModels.JoiningTableModels;
using FitnessTracker.Models.WorkoutModels.ExerciseModels;
using FitnessTracker.Models.WorkoutModels.WorkoutModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services.WorkoutServices
{
    public class WorkoutService
    {
        //private field
        private readonly Guid _userId;

        public WorkoutService(Guid userId)
        {
            _userId = userId;
        }

        //Get all workouts
        public IEnumerable<WorkoutListItem> GetAllWorkouts()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Workouts
                    .Where(w => w.OwnerId == _userId)
                    .Select(
                        w =>
                        new WorkoutListItem
                        {
                            WorkoutId = w.WorkoutId,
                            Title = w.Title,
                            WorkoutPlanId = w.WorkoutPlanId
                        }
                        );
                return query.ToArray();
            }
        }

        //Create new workout
        public bool CreateWorkout(WorkoutCreate model)
        {
            var entity =
                new Workout()
                {
                    Title = model.Title,
                    OwnerId = _userId,
                    WorkoutPlanId = model.WorkoutPlanId
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Workouts.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //Get workout by Id
        public WorkoutDetail GetWorkoutById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Workouts
                    .Single(w => w.WorkoutId == id && w.OwnerId == _userId);

                return new WorkoutDetail
                {
                    WorkoutId = entity.WorkoutId,
                    Title = entity.Title,
                    WorkoutPlanId = entity.WorkoutPlanId,
                    Exercises =
                        ctx
                        .ExerciseForWorkouts
                        .Where(e => e.WorkoutId == entity.WorkoutId)
                        .Select(ei =>
                            new ExerciseForWorkoutListItem
                            {
                                Id = ei.Id,
                                ExerciseId = ei.ExerciseId,
                                WorkoutId = ei.WorkoutId,
                                Exercise = new ExerciseListItem
                                {
                                    ExerciseId = ei.ExerciseId,
                                    Name = ei.Exercise.Name,
                                    Type = ei.Exercise.Type,
                                }
                            }
                            ).ToList()
                };
            }
        }

        //Edit Workout
        public bool UpdateWorkout(WorkoutUpdate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Workouts
                    .Single(w => w.WorkoutId == model.WorkoutId && w.OwnerId == _userId);

                entity.Title = model.Title;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete workout
        public bool DeleteWorkout(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Workouts
                    .Single(w => w.WorkoutId == id && w.OwnerId == _userId);

                var related =
                    ctx
                    .WorkoutForWorkoutPlans
                    .Single(w => w.WorkoutId == id && w.Workout.OwnerId == _userId);

                ctx.WorkoutForWorkoutPlans.Remove(related);
                ctx.Workouts.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
