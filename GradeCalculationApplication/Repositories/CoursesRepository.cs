using GradeCalculationApplication.DTOs;
using GradeCalculationApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeCalculationApplication.Repositories
{
    public class CoursesRepository
    {
        private readonly GradeCalculationContext _context;

        public CoursesRepository(GradeCalculationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllEnrolledStudentsInCourseQueryResponse>> GetAllEnrolledStudentsInCourse(int courseID)
        {
            var students = await _context.StudentCourses.Where(sc => sc.CourseID == courseID)
                .Select(sc => new GetAllEnrolledStudentsInCourseQueryResponse
                {
                    StudentName = sc.Student.StudentName,
                    IdentifcationNumber = sc.Student.StudentNumber,
                    GradeReceived = sc.EnumGrade.ToString()
                }).ToListAsync();

            return students;
        }
    }
}