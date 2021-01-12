using FitnessTracker.Models.MealModels.JoiningTableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.WorkoutModels.WorkoutPlan
{
    public class WorkoutPlanDetail
    {
        [Display(Name = "Workout Plan #")]
        public int WorkoutPlanId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreatedUtc { get; set; }

        [Display(Name = "Date Modified")]
        public DateTimeOffset? DateModifiedUtc { get; set; }

        public List<WorkoutForWorkoutPlanListItem> Workouts { get; set; }
    }
}
