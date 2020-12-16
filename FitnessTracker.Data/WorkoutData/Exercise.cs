using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data.WorkoutData
{
    public enum Type { Cardio, Weight};
    public enum MuscleGroup { Chest = 1, FDeltoid, Biceps, Forearms, Abdominals, Obliques, Quadriceps, Tibialis, Trapezius, RDeltoid, MiddleBack, Triceps, LowerBack, Glutes, Hamstrings, Calf }
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Repetition { get; set; }
        public int Sets { get; set; }
        public int Length { get; set; }
        public Type Type { get; set; }

        public MuscleGroup Muscle { get; set; }

        //add reference tables here
    }
}
