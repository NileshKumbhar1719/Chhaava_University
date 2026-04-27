using Course.Models;
using Course.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Coursess : ControllerBase
    {
        private readonly IServiceCourse _Service;

        public Coursess(IServiceCourse serviceCourse) 
        {
         _Service=serviceCourse;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
             var data = await _Service.AllGetdata();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> create([FromBody] Courses courses)
        {
            var data = await _Service.create(courses);
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Courses courses,int id)
        {
            if (courses == null || id != courses.Id)
            {
                return BadRequest();
            }

            var data = await _Service.Update(id, courses);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyID(int id)
        {
            var data = await _Service.GetbyIDdata(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _Service.Delete(id);

            if (!result)
            {
                return NotFound("Course not found");
            }

            return NoContent();
        }
    }
}
