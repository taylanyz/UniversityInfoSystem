using Microsoft.AspNetCore.Mvc;
using UniversityInfoSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityInfoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> _students = new List<Student>
        {
            new Student { Id = 44488883333, Name = "Emin Talip Demirkiran", Email = "etd@eskisehir.edu.tr", Courses = new List<string> { "BIM308", "BIM439", "BBO102" } }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(_students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(long id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> AddStudent([FromBody] Student student)
        {
            if (_students.Any(s => s.Id == student.Id)) return BadRequest("Student with this ID already exists.");
            _students.Add(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(long id, [FromBody] Student updatedStudent)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.Courses = updatedStudent.Courses;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(long id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            _students.Remove(student);
            return NoContent();
        }
    }
}