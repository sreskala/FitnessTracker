using FitnessTracker.Data.WorkoutData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.WorkoutModels.ExerciseModels
{
    public class ExerciseListItem
    {
        [Display(Name = "Exercise #" )]
        public int ExerciseId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Workout Type")]
        public WorkoutType Type { get; set; }

        [Display(Name = "Tied to Workout #")]
        public int WorkoutId { get; set; }
    }
}
