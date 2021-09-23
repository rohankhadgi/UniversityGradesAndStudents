using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GradeCalculationApplication.Models;
using GradeCalculationApplication.Models.Entities;
using GradeCalculationApplication.Services;
using System.Threading;

namespace GradeCalculationApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly GradeCalculationContext _context;

        public StudentsController(GradeCalculationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetStudents(CancellationToken cancellationToken)
        {
            return Ok(await _context.Students.ToListAsync(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentEntity>> GetStudentEntity(int id)
        {
            var studentEntity = await _context.Students.FindAsync(id);

            if (studentEntity == null)
            {
                return NotFound();
            }

            return studentEntity;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentEntity(int id, StudentEntity studentEntity)
        {
            if (id != studentEntity.StudentID)
            {
                return BadRequest();
            }

            _context.Entry(studentEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<StudentEntity>> PostStudentEntity(StudentEntity studentEntity)
        {
            
            var courses = await _context.Courses.Where(c => studentEntity.StudentCourses.Select(x => x.CourseID).Contains(c.CourseID)).ToListAsync();

            foreach(var course in studentEntity.StudentCourses)
            {
                course.Course = courses.Where(x => x.CourseID == course.CourseID).FirstOrDefault();
            }
            
            _context.Students.Add(studentEntity);
            await _context.SaveChangesAsync();

            var calculationData = studentEntity.StudentCourses.Where(sc => sc.IsCalculated)
                .Select(x => new
                {
                    QualityPoints = x.Grade * x.Course.CourseCredit,
                    CourseCredit = x.Course.CourseCredit
                }).ToList();

            var totalQualityPoints = (decimal)calculationData.Sum(x => x.QualityPoints);
            var totalCredits = (decimal)calculationData.Sum(x => x.CourseCredit);

            var gpa = totalQualityPoints / totalCredits;

            studentEntity.CGPA = gpa;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentEntity(int id)
        {
            var studentEntity = await _context.Students.FindAsync(id);
            if (studentEntity == null)
            {
                return NotFound();
            }

            _context.Students.Remove(studentEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("student/{studentID}/get-student-courses")]
        public async Task<IActionResult> GetStudentCourses(int stundentID, CancellationToken cancellationToken)
        {
            var studentCourses = await _context.StudentCourses.Where(sc => sc.StudentID == stundentID).ToListAsync(cancellationToken);

            return Ok(studentCourses);
        }

        //[HttpGet("student/{studentID}/get-all-student-courses")]
        //public async Task<IActionResult> GetStudentCourses(int studentID, CancellationToken cancellationToken)
        //{
        //    var result = await _studentsServices.GetAllEnrolledStudentsInCourse(studentID, cancellationToken);
        //    return Ok(result);
        //}

        private bool StudentEntityExists(int id)
        {
            return _context.Students.Any(e => e.StudentID == id);
        }
    }
}
