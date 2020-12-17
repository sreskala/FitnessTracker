using FitnessTracker.Models.MealModels.JoiningTableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.MealPlan
{
    public class MealPlanListItem
    {
        public int MealPlanId { get; set; }
        public string Title { get; set; }
        //public int Week { get; set; }

        [Display(Name ="Date Created")]
        public DateTimeOffset DateCreatedUtc { get; set; }
        
    }
}
