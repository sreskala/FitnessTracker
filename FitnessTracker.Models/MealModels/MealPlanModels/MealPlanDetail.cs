using FitnessTracker.Data.MealData;
using FitnessTracker.Models.MealModels.JoiningTableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.MealPlan
{
    public class MealPlanDetail
    {
        [Display(Name = "Meal Plan #")]
        public int MealPlanId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreatedUtc { get; set; }

        [Display(Name = "Date Modified")]
        public DateTimeOffset? DateModifiedUtc { get; set; }

        [Display(Name = "Length of Meal Plan in Weeks")]
        public int? Length { get; set; }

        public List<MealForMealPlanListItem> Meals { get; set; }
    }
}
