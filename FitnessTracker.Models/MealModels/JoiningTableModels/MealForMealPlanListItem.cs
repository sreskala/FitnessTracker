using FitnessTracker.Models.MealModels.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.JoiningTableModels
{
    public class MealForMealPlanListItem
    {
        public int Id { get; set; }
        public int MealPlanId { get; set; }
        public int MealId { get; set; }
        public MealListItem Meal { get; set; }
    }
}
