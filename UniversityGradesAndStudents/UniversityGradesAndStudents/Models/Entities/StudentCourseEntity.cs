namespace UniversityGradesAndStudents.Models.Entities
{
    public class StudentCourseEntity
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public StudentEntity Student { get; set; }
        public CourseEntity Course { get; set; }
    }
}
