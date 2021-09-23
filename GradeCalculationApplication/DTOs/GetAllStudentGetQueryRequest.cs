using System.Collections.Generic;

namespace GradeCalculationApplication.DTOs
{
    public class GetAllStudentGetQueryRequest
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public decimal? CGPA { get; set; }
        public List<GetAllEnrolledCoursesQueryResponse> StudentCourses { get; set; }
    }
}
