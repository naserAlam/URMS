using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace URMS.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        public string Grade { get; set; }
        public int Mark { get; set; }
        public int GradeReportId { get; set; }
        public GradeReport GradeReport { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
