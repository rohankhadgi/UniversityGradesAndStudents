using GradeCalculationApplication.DTOs;
using GradeCalculationApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GradeCalculationApplication.Repositories
{
    public class StudentsRepository
    {
        private readonly GradeCalculationContext _context;

        public StudentsRepository(GradeCalculationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllEnrolledCoursesQueryResponse>> GetAllEnrolledCourses(int studentID, CancellationToken cancellationToken)
        {
            var students = await _context.StudentCourses.Where(sc => sc.StudentID == studentID)
                .Select(sc => new GetAllEnrolledCoursesQueryResponse
                {
                    CourseName = sc.Course.CourseName,
                    CourseCode = sc.Course.CourseCode,
                    CourseCredit = sc.Course.CourseCredit,
                    GradeReceived = sc.EnumGrade.ToString()
                }).ToListAsync(cancellationToken);

            return students;
        }

        public async Task<IEnumerable<GetAllStudentGetQueryRequest>> GetAllStudents(CancellationToken cancellationToken)
        {
            var allStudents = await _context.Students
                .Select(s => new GetAllStudentGetQueryRequest 
                {
                    StudentName = s.StudentName,
                    StudentNumber = s.StudentNumber,
                    CGPA = s.CGPA,
                    StudentID = s.StudentID
                }).ToListAsync(cancellationToken);

            foreach(var student in allStudents)
            {
                var studentCourses = await GetAllEnrolledCourses(student.StudentID, cancellationToken);
                student.StudentCourses = studentCourses.ToList();
            }

            return allStudents;
        }
    }
}
