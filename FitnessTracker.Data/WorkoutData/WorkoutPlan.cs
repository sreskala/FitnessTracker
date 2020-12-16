using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data.WorkoutData
{
    public class WorkoutPlan
    {
        [Key]
        public int WorkoutPlanId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Too many characters.")]
        public string Title { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreatedUtc { get; set; }

        [Display(Name = "Date Modified")]
        public DateTimeOffset? DateModifiedUtc { get; set; }
        public Guid OwnerId { get; set; }

        //reference other tables here?
    }
}
