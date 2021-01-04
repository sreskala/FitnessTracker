using FitnessTracker.Models.MealModels.JoiningTableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.WorkoutModels.WorkoutModels
{
    public class WorkoutDetail
    {
        public int WorkoutId { get; set; }
        public string Title { get; set; }
        public int WorkoutPlanId { get; set; }

        public List<ExerciseForWorkoutListItem> Exercises { get; set; }
    }
}
