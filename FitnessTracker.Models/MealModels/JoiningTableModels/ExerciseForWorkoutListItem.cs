using FitnessTracker.Models.WorkoutModels.ExerciseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.JoiningTableModels
{
    public class ExerciseForWorkoutListItem
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public ExerciseListItem Exercise { get; set; }
    }
}
