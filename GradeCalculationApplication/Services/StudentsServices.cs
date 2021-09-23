using GradeCalculationApplication.DTOs;
using GradeCalculationApplication.Models;
using GradeCalculationApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GradeCalculationApplication.Services
{
    public class StudentsServices
    {
        private readonly GradeCalculationContext _context;
        private readonly StudentsRepository _studentsRepository;
        public StudentsServices(GradeCalculationContext context,
            StudentsRepository studentsRepository)
        {
            _context = context;
            _studentsRepository = studentsRepository;
        }

        public async Task<IEnumerable<GetAllEnrolledCoursesQueryResponse>> GetAllEnrolledStudentsInCourse(int courseID, CancellationToken cancellationToken)
        {
            return await _studentsRepository.GetAllEnrolledCourses(courseID, cancellationToken);
        }

        public async Task<IEnumerable<GetAllStudentGetQueryRequest>> GetAllStudents(CancellationToken cancellationToken)
        {
            return await _studentsRepository.GetAllStudents(cancellationToken);
        }
    }
}
