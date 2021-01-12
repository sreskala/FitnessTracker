using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.GoalModels
{
    public class GoalDetail
    {
        [Display(Name = "Goal #")]
        public int GoalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreatedUtc { get; set; }

        [Display(Name = "Date Modified")]
        public DateTimeOffset? DateModifiedUtc { get; set; }

        public bool Completed { get; set; }
    }
}
