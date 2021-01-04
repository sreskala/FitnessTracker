using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data.WorkoutData
{
    public class ExerciseForWorkout
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int WorkoutId { get; set; }
        [ForeignKey(nameof(WorkoutId))]
        public virtual Workout Workout { get; set; }

        [Required]
        public int ExerciseId { get; set; }
        [ForeignKey(nameof(ExerciseId))]
        public virtual Exercise Exercise { get; set; }
    }
}
