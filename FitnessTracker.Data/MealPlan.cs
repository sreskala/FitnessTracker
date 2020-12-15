using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data
{
    public class MealPlan
    {
        [Key]
        public int MealPlanId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name of meal plan cannot exceed 100 characters.")]
        public string Title { get; set; }

        public int Week { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreatedUtc { get; set; }

        [Display(Name = "Date Modified")]
        public DateTimeOffset? DateModifiedUtc { get; set; }
        public int? Length { get; set; }
        public Guid OwnerId { get; set; }
        
        //Reference to other tables here
    }
}
