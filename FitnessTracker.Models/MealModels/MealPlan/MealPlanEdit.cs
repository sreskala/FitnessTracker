using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.MealPlan
{
    public class MealPlanEdit
    {
        public int MealPlanId { get; set; }
        public string Title { get; set; }
        public int? Length { get; set; }
    }
}
