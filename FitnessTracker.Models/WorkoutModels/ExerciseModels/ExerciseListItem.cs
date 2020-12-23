using FitnessTracker.Data.WorkoutData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.WorkoutModels.ExerciseModels
{
    public class ExerciseListItem
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public WorkoutType Type { get; set; }
        public int WorkoutId { get; set; }
    }
}
