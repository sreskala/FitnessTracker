using FitnessTracker.Models.MealModels.JoiningTableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.Meal
{
    public class MealDetail
    {
        [Display(Name = "Meal #")]
        public int MealId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Tied to Meal Plan #")]
        public int MealPlanId { get; set; }

        public List<FoodItemForMealListItem> FoodItems { get; set; }
    }
}
