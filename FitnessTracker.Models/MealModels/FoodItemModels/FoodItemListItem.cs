using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.FoodItemModels
{
    public class FoodItemListItem
    {
        public int FoodItemId { get; set; }
        public string Name { get; set; }
        public int MealId { get; set; }
    }
}
