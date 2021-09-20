using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeCalculationApplication.Models.Entities
{
    public class StudentEntity
    {
        [Key]
        public int StudentID { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string StudentName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string StudentNumber { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? CGPA { get; set; }
        public ICollection<StudentCourseEntity> StudentCourses { get; set; }
    }
}
