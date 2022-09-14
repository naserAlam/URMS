using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using URMS.Areas.Identity.Data;

namespace URMS.Models
{
    public class Evaluation
    {
        [Key]
        public int EvaluationId { get; set; }
        public string Semester { get; set; }
        public int Score { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string URMSUserId { get; set; }
        public URMSUser URMSUser { get; set; }
    }
}
