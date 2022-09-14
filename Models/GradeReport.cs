using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using URMS.Areas.Identity.Data;

namespace URMS.Models
{
    public class GradeReport
    {
        [Key]
        public int GradeReportId { get; set; }
        public string Semester { get; set; }
        public string URMSUserId { get; set; }
        public URMSUser URMSUser { get; set; }
    }
}
