using FitnessTracker.Models.MealModels.JoiningTableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.Meal
{
    public class MealDetail
    {
        public int MealId { get; set; }
        public string Title { get; set; }

        public int MealPlanId { get; set; }

        public List<FoodItemForMealListItem> FoodItems { get; set; }
    }
}
