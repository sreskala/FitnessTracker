using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data
{
    public class FoodItem
    {
        [Key]
        public int FoodItemId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Too many characters.")]
        public string Name { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "Value is too large.")]
        public int Quantity { get; set; }
        public int Calories { get; set; }
        public Guid OwnerId { get; set; }

        //Reference to meals
        [Required]
        [ForeignKey(nameof(Meal))]
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
