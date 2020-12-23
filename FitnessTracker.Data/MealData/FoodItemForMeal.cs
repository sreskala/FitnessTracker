using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data.MealData
{
    public class FoodItemForMeal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MealId { get; set; }

        [ForeignKey(nameof(MealId))]
        public virtual Meal Meal { get; set; }

        [Required]
        public int FoodItemId { get; set; }

        [ForeignKey(nameof(FoodItemId))]
        public virtual FoodItem FoodItem { get; set; }
    }
}
