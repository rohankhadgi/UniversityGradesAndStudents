using System.Collections.Generic;

namespace UniversityGradesAndStudents.Models.Entities
{
    public class StudentEntity
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public ICollection<CourseEntity> StudentCourses { get; set; }
    }
}
