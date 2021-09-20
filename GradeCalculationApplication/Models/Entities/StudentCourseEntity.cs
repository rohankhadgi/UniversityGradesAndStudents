using GradeCalculationApplication.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeCalculationApplication.Models.Entities
{
    public class StudentCourseEntity
    {
        [Key, Column(Order = 0), ForeignKey("Student")]
        public int StudentID { get; set; }
        [Key, Column(Order = 1), ForeignKey("Course")]
        public int CourseID { get; set; }
        [Column(TypeName = "int")]
        public Grade? Grade { get; set; }
        public bool IsCalculated { get; set; }
        public bool HasPassed { get; set; }
        public StudentEntity Student { get; set; }
        public CourseEntity Course { get; set; }
    }
}
