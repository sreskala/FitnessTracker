using FitnessTracker.Data;
using FitnessTracker.Data.WorkoutData;
using FitnessTracker.Models.WorkoutModels.ExerciseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services.WorkoutServices
{
    public class ExerciseService
    {
        //initialize field
        private readonly Guid _userId;

        public ExerciseService(Guid userId)
        {
            _userId = userId;
        }

        //Get all exercises
        public IEnumerable<ExerciseListItem> GetAllExercises()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Exercises
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ExerciseListItem()
                        {
                            ExerciseId = e.ExerciseId,
                            Name = e.Name,
                            Type = e.Type,
                            WorkoutId = e.WorkoutId
                        });
                return query.ToArray();
            }
        }

        //Get one exercise by id
        public ExerciseDetail GetExerciseById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Exercises
                    .Single(e => e.ExerciseId == id && e.OwnerId == _userId);

                return new ExerciseDetail()
                {
                    ExerciseId = entity.ExerciseId,
                    Name = entity.Name,
                    Description = entity.Description,
                    Repetition = entity.Repetition,
                    Sets = entity.Sets,
                    Length = entity.Length,
                    Muscle = entity.Muscle,
                    Type = entity.Type,
                    WorkoutId = entity.WorkoutId
                };
            }
        }

        //Create new exercise
        public bool CreateExercise(ExerciseCreate model)
        {
            var entity =
                new Exercise()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Repetition = model.Repetition,
                    Sets = model.Sets,
                    Length = model.Length,
                    Type = model.Type,
                    Muscle = model.Muscle,
                    OwnerId = _userId,
                    WorkoutId = model.WorkoutId
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Exercises.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Update new exercise
        public bool UpdateExercise(ExerciseUpdate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Exercises
                    .Single(e => e.ExerciseId == model.ExerciseId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Repetition = model.Repetition;
                entity.Sets = model.Sets;
                entity.Muscle = model.Muscle;
                entity.Type = model.Type;
                entity.Length = model.Length;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete Exercise
        public bool DeleteExercise(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Exercises
                    .Single(e => e.ExerciseId == id && e.OwnerId == _userId);

                var related =
                    ctx
                    .ExerciseForWorkouts
                    .Single(e => e.ExerciseId == id && e.Exercise.OwnerId == _userId);

                ctx.ExerciseForWorkouts.Remove(related);
                ctx.Exercises.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
