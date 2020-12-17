using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.Meal
{
    public class MealListItem
    {
        public int MealId { get; set; }
        public string Title { get; set; }
        public int MealPlanId { get; set; }
    }
}
