using FitnessTracker.Models.MealModels.MealPlan;
using FitnessTracker.Models.WorkoutModels.WorkoutPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class PlanMergeMealWorkout
    {
        public MealPlanListItem MealPlan { get; set; }
        public WorkoutPlanListItem WorkoutPlan { get; set; }
    }
}
