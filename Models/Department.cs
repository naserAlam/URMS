using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace URMS.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string CoordinatorName { get; set; }
        public List<Course> Courses { get; set; }
    }
}
