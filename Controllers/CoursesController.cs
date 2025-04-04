using Microsoft.AspNetCore.Mvc;
using UniversityInfoSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityInfoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private static List<Course> _courses = new List<Course>
        {
            new Course { Id = "BIM308", Title = "Web Server Programming", Classroom = "B6" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            return Ok(_courses);
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourse(string id)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public ActionResult<Course> AddCourse([FromBody] Course course)
        {
            if (_courses.Any(c => c.Id == course.Id)) return BadRequest("Course with this ID already exists.");
            _courses.Add(course);
            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCourse(string id, [FromBody] Course updatedCourse)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();
            course.Title = updatedCourse.Title;
            course.Classroom = updatedCourse.Classroom;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(string id)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();
            _courses.Remove(course);
            return NoContent();
        }
    }
}