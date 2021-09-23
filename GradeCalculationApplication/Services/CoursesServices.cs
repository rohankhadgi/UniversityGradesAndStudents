using GradeCalculationApplication.DTOs;
using GradeCalculationApplication.Models;
using GradeCalculationApplication.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeCalculationApplication.Services
{
    public class CoursesServices
    {
        private readonly GradeCalculationContext _context;
        private readonly CoursesRepository _coursesRepository;

        public CoursesServices(GradeCalculationContext context,
            CoursesRepository coursesRepository)
        {
            _context = context;
            _coursesRepository = coursesRepository;
        }

        public async Task<IEnumerable<GetAllEnrolledStudentsInCourseQueryResponse>> GetAllEnrolledStudentsInCourse(int courseID)
        {
            return await _coursesRepository.GetAllEnrolledStudentsInCourse(courseID);
        }
    }
}
