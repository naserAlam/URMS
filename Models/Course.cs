using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace URMS.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int ResultId { get; set; }
        public Result Result { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int EvaluationId { get; set; }
        public Evaluation Evaluation { get; set; }
        public List<Registration> Registrations { get; set; }
    }
}
