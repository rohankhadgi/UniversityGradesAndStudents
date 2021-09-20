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
    public class StudentsController : ControllerBase
    {
        private readonly GradeCalculationContext _context;

        public StudentsController(GradeCalculationContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentEntity>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
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

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentEntity>> PostStudentEntity(StudentEntity studentEntity)
        {
            
            _context.Students.Add(studentEntity);
            await _context.SaveChangesAsync();

            var calculationData = studentEntity.StudentCourses.Where(sc => sc.IsCalculated)
                .Select(x => new
                {
                    QualityPoints = (int)x.Grade * x.Course.CourseCredit,
                    CourseCredit = x.Course.CourseCredit
                }).ToList();

            var totalQualityPoints = calculationData.Sum(x => x.QualityPoints);
            var totalCredits = calculationData.Sum(x => x.CourseCredit);

            var gpa = (double)totalQualityPoints / (double)totalCredits;

            studentEntity.CGPA = (decimal)gpa;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentEntity", new { id = studentEntity.StudentID }, studentEntity);
        }

        // DELETE: api/Students/5
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

        private bool StudentEntityExists(int id)
        {
            return _context.Students.Any(e => e.StudentID == id);
        }
    }
}
