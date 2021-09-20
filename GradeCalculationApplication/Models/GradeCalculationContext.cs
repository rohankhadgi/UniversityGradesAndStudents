using Microsoft.EntityFrameworkCore;
using GradeCalculationApplication.Models.Entities;

namespace GradeCalculationApplication.Models
{
    public class GradeCalculationContext : DbContext
    {
        public GradeCalculationContext(DbContextOptions<GradeCalculationContext> contextOptions) : base(contextOptions)
        {
        
        }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<StudentCourseEntity> StudentCourses { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourseEntity>().HasKey(sc => new { sc.StudentID, sc.CourseID });
        }
    }
}
