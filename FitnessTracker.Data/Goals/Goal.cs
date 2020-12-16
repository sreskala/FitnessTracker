using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data.Goals
{
    public class Goal
    {
        [Key]
        public int GoalId { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage = "Too many characters.")]
        public string Title { get; set; }

        [Required]
        [MaxLength(10000, ErrorMessage = "Cannot exceed 10,000 characters")]
        public string Description { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreatedUtc { get; set; }

        [Display(Name = "Date Modified")]
        public DateTimeOffset? DateModifiedUtc { get; set; }

        public bool Completed { get; set; }

        public Guid OwnerId { get; set; }
    }
}
