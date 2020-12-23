using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data.WorkoutData
{
    public enum WorkoutType { Cardio = 1, Weight};
    public enum MuscleGroup { Chest = 1, FDeltoid, Biceps, Forearms, Abdominals, Obliques, Quadriceps, Tibialis, Trapezius, RDeltoid, MiddleBack, Triceps, LowerBack, Glutes, Hamstrings, Calf }
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name too long.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Too many characters.")]
        public string Description { get; set; }

        public int Repetition { get; set; }
        public int Sets { get; set; }
        public int Length { get; set; }
        public WorkoutType Type { get; set; }

        public MuscleGroup Muscle { get; set; }

        public Guid OwnerId { get; set; }

        //Reference to workout
        [Required]
        [ForeignKey(nameof(Workout))]
        public int WorkoutId { get; set; }
        public virtual Workout Workout { get; set; }
    }
}
