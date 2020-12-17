using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.WorkoutModels.WorkoutModels
{
    public class WorkoutCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Too many characters.")]
        public string Title { get; set; }

        [Required]
        public int WorkoutPlanId { get; set; }
    }
}
