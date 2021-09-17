using Microsoft.EntityFrameworkCore;
using UniversityGradesAndStudents.Models.Entities;

namespace UniversityGradesAndStudents.Models
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<StudentCourseEntity> StudentCourses { get; set; }
    }
}
