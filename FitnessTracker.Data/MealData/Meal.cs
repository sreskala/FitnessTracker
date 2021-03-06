﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data
{
    public class Meal
    {
        [Key]
        public int MealId { get; set; }
        [Required]
        public string Title { get; set; }
        public Guid OwnerId { get; set; }

        //Reference to food items
        [Required]
        [ForeignKey(nameof(MealPlan))]
        public int MealPlanId { get; set; }
        public virtual MealPlan MealPlan { get; set; }
    }
}
