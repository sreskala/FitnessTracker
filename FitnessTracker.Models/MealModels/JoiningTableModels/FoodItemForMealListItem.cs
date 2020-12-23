using FitnessTracker.Models.MealModels.FoodItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.JoiningTableModels
{
    public class FoodItemForMealListItem
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public int FoodItemId { get; set; }
        public FoodItemListItem FoodItem { get; set; }
    }
}
