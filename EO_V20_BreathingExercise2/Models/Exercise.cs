using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EO_V20_BreathingExercise2.Models
{
    public class Exercise
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int Minutes { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public string UserName { get; set; }
    }
}
