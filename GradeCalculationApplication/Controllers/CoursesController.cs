using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GradeCalculationApplication.Models;
using GradeCalculationApplication.Models.Entities;

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

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseEntity>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Courses/5
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

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseEntity>> PostCourseEntity(CourseEntity courseEntity)
        {
            _context.Courses.Add(courseEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseEntity", new { id = courseEntity.CourseID }, courseEntity);
        }

        // DELETE: api/Courses/5
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

        private bool CourseEntityExists(int id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }
    }
}
