using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using URMS.Models;

namespace URMS.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the URMSUser class
    public class URMSUser : IdentityUser
    {
        public int GradeReportId { get; set; }
        public List<GradeReport> GradeReports { get; set; }
        public List<Evaluation> Evaluations { get; set; }
        public List<Registration> Registrations { get; set; }
        public List<Complaint> Complaints { get; set; }

    }
}
