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
    public class CoursesController : ControllerBase
    {
        private readonly GradeCalculationContext _context;

        public CoursesController(GradeCalculationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseEntity>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseEntity>> GetCourseEntity(int id)
        {
            var courseEntity = await _context.Courses.FindAsync(id);

            if (courseEntity == null)
            {
                return NotFound();
            }

            return courseEntity;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseEntity(int id, CourseEntity courseEntity)
        {
            if (id != courseEntity.CourseID)
            {
                return BadRequest();
            }

            _context.Entry(courseEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseEntityExists(id))
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

        [HttpGet("course/{courseID}/get-enrolled-students")]
        public async Task<IActionResult> GetEnrolledStudentsInCourse(int courseID, CancellationToken cancellationToken)
        {
            var enrolledStudents = await _context.StudentCourses.Where(sc => sc.CourseID == courseID).ToListAsync(cancellationToken);

            return Ok(enrolledStudents);
        }

        [HttpPost]
        public async Task<ActionResult<CourseEntity>> PostCourseEntity(CourseEntity courseEntity)
        {
            _context.Courses.Add(courseEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseEntity", new { id = courseEntity.CourseID }, courseEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseEntity(int id)
        {
            var courseEntity = await _context.Courses.FindAsync(id);
            if (courseEntity == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(courseEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpGet("course/{courseID}/get-all-enrolled-students")]
        //public async Task<IActionResult> GetAllEnrolledStudents(int courseID)
        //{
        //    var result = await _coursesServices.GetAllEnrolledStudentsInCourse(courseID);
        //    return Ok(result);
        //}

        private bool CourseEntityExists(int id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }
    }
}
