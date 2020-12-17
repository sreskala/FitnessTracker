using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data.MealData
{
    //joining table
    public class MealForMealPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MealPlanId { get; set; }

        [ForeignKey(nameof(MealPlanId))]
        public virtual MealPlan MealPlan { get; set; }

        [Required]
        public int MealId { get; set; }

        [ForeignKey(nameof(MealId))]
        public virtual Meal Meal { get; set; }
    }
}
