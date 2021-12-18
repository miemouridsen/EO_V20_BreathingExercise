using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EO_V20_BreathingExercise2.Models
{
    public class ExercisePagemodel
    {
        public List<Exercise> Exercises { get; set; } = new();
        public int TotalMinutes { get; set; }
    }
}
