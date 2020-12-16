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
        public int MealPlanId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreatedUtc { get; set; }

        [Display(Name = "Date Modified")]
        public DateTimeOffset? DateModifiedUtc { get; set; }
        public int? Length { get; set; }
    }
}
