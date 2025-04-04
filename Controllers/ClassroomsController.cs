using Microsoft.AspNetCore.Mvc;
using UniversityInfoSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityInfoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private static List<Classroom> _classrooms = new List<Classroom>
        {
            new Classroom { Id = "B6", Description = "Computer Engineering Ground Floor", Capacity = 60 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Classroom>> GetClassrooms()
        {
            return Ok(_classrooms);
        }

        [HttpGet("{id}")]
        public ActionResult<Classroom> GetClassroom(string id)
        {
            var classroom = _classrooms.FirstOrDefault(c => c.Id == id);
            if (classroom == null) return NotFound();
            return Ok(classroom);
        }
    }
}