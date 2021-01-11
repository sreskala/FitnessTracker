using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.WorkoutModels.WorkoutPlan
{
    public class WorkoutPlanListItem
    {
        [Display(Name = "Workout Plan #")]
        public int WorkoutPlanId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreatedUtc { get; set; }
    }
}
