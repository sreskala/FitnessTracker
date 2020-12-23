﻿using FitnessTracker.Data.WorkoutData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.WorkoutModels.ExerciseModels
{
    public class ExerciseUpdate
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Repetition { get; set; }
        public int Sets { get; set; }
        public int Length { get; set; }
        public WorkoutType Type { get; set; }
        public MuscleGroup Muscle { get; set; }
    }
}
