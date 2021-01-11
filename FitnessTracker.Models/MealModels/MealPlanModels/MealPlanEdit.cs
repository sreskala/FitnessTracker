using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.MealPlan
{
    public class MealPlanEdit
    {
        public int MealPlanId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Length in Weeks")]
        public int? Length { get; set; }
    }
}
