﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.MealModels.FoodItemModels
{
    public class FoodItemDetail
    {
        [Display(Name = "Food Item #")]
        public int FoodItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Calories { get; set; }

        [Display(Name = "Tied to Meal #")]
        public int MealId { get; set; }
    }
}
