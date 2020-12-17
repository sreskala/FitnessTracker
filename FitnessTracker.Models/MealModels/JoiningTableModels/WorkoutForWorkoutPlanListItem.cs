using FitnessTracker.Models.WorkoutModels.WorkoutModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.JoiningTableModels
{
    public class WorkoutForWorkoutPlanListItem
    {
        public int Id { get; set; }
        public int WorkoutPlanId { get; set; }
        public int WorkoutId { get; set; }
        public WorkoutListItem Workout { get; set; }
    }
}
