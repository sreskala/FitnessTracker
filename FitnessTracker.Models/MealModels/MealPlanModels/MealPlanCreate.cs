using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.MealPlan
{
    public class MealPlanCreate
    {
        [Required]
        [MinLength(5, ErrorMessage ="Please enter at least 5 characters")]
        [MaxLength(100,ErrorMessage ="Too many characters.")]
        public string Title { get; set; }

        [Display(Name = "Length in Weeks")]
        public int Length { get; set; }
    }
}
