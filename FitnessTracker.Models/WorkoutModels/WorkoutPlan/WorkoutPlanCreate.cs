using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.WorkoutModels.WorkoutPlan
{
    public class WorkoutPlanCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Too many characters")]
        public string Title { get; set; }
    }
}
