using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FitnessTracker.Models.MealModels.Meal
{
    public class MealCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Too many characters.")]
        public string Title { get; set; }

        [Required]
        public int MealPlanId { get; set; }
    }
}
