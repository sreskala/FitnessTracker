using FitnessTracker.Data.WorkoutData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.WorkoutModels.ExerciseModels
{
    public class ExerciseCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name too long")]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Too many characters.")]
        public string Description { get; set; }
        public int Repetition { get; set; }
        public int Sets { get; set; }
        public int Length { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select an item.")]
        public WorkoutType Type { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select an item.")]
        public MuscleGroup Muscle { get; set; }

        [Required]
        public int WorkoutId { get; set; }
    }
}
