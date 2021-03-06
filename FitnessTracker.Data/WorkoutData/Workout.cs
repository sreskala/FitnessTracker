﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data.WorkoutData
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }

        [Required]
        public string Title { get; set; }

        public Guid OwnerId { get; set; }

        //reference other tables here

        [Required]
        [ForeignKey(nameof(WorkoutPlan))]
        public int WorkoutPlanId { get; set; }
        public virtual WorkoutPlan WorkoutPlan { get; set; }
    }
}
