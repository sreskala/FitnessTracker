using FitnessTracker.Data.WorkoutData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.WorkoutModels.ExerciseModels
{
    public class ExerciseDetail
    {
        [Display(Name = "Exercise #")]
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Reps")]
        public int Repetition { get; set; }
        public int Sets { get; set; }

        [Display(Name = "Length in Minutes")]
        public int Length { get; set; }

        [Display(Name = "Workout Type")]
        public WorkoutType Type { get; set; }

        public MuscleGroup Muscle { get; set; }

        [Display(Name = "Tied to Workout #")]
        public int WorkoutId { get; set; }
    }
}
