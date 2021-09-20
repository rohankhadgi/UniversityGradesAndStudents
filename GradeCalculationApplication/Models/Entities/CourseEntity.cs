using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeCalculationApplication.Models.Entities
{
    public class CourseEntity
    {
        [Key]
        public int CourseID { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string CourseName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string CourseCode { get; set; }
        [Column(TypeName = "int")]
        public int CourseCredit { get; set; }
        public ICollection<StudentCourseEntity> StudentCourses { get; set; }
    }
}
