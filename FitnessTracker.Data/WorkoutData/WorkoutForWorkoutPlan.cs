using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data.WorkoutData
{
    public class WorkoutForWorkoutPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(WorkoutPlan))]
        public int WorkoutPlanId { get; set; }
        public virtual WorkoutPlan WorkoutPlan { get; set; }
        
        [Required]
        [ForeignKey(nameof(Workout))]
        public int WorkoutId { get; set; }
        public virtual Workout Workout { get; set; }
    }
}
