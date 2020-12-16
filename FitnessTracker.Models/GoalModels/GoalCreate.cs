using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.GoalModels
{
    public class GoalCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Cannot exceed 100 characters")]
        public string Title { get; set; }

        [Required]
        [MaxLength(10000, ErrorMessage = "Cannot exceed 10,000 characters")]
        public string Description { get; set; }
    }
}
