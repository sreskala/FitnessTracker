using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.FoodItemModels
{
    public class FoodItemCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage ="Too many characters.")]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Calories { get; set; }

        [Required]
        public int MealId { get; set; }
    }
}
