using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


    }
}
