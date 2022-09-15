using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using URMS.Areas.Identity.Data;
using URMS.Models;

namespace URMS.Data
{
    public class URMSDbContext : IdentityDbContext<URMSUser>
    {
        public URMSDbContext(DbContextOptions<URMSDbContext> options)
            : base(options)
        {
        }
        public DbSet<GradeReport> GradeReports { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<URMSUser>()
                .HasMany(u => u.GradeReports)
                .WithOne(g => g.URMSUser);

            builder.Entity<GradeReport>()
                .HasMany(g => g.Results)
                .WithOne(r => r.GradeReport);

            builder.Entity<Course>()
                .HasMany(c => c.Results)
                .WithOne(r => r.Course);

            builder.Entity<Department>()
                .HasMany(d => d.Courses)
                .WithOne(c => c.Department);

            builder.Entity<Course>()
                .HasMany(c => c.Evaluations)
                .WithOne(e => e.Course);

            builder.Entity<URMSUser>()
                .HasMany(u => u.Evaluations)
                .WithOne(e => e.URMSUser);

            builder.Entity<URMSUser>()
                .HasMany(u => u.Registrations)
                .WithOne(r => r.URMSUser);

            builder.Entity<Course>()
                .HasMany(c => c.Registrations)
                .WithOne(r => r.Course);

            builder.Entity<URMSUser>()
                .HasMany(u => u.Complaints)
                .WithOne(c => c.URMSUser);
        }
    }
}
