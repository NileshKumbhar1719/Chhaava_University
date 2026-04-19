using Chhaava_University.Models;
using Chhaava_University.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chhaava_University.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService _service;
        private readonly ILogger<University> _Logger;

        public UniversityController(IUniversityService service,ILogger<University> logger)
        {
            _service = service;
            _Logger = logger;
        }

        // GET: api/university
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           
            var result = await _service.GetAllAsync();
            _Logger.LogInformation("User all Data show ");
            return Ok(result);
        }

        // GET: api/university/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound("University not found");

            return Ok(result);
        }

        // POST: api/university
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] University university)
        {
            if (university == null)
                return BadRequest("Invalid data");

            var result = await _service.CreateAsync(university);

            return Ok(result);
        }

        // PUT: api/university
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] University university)
        {
            if (university == null)
                return BadRequest("Invalid data");

            var result = await _service.UpdateAsync(university);

            if (result == null)
                return NotFound("University not found");

            return Ok(result);
        }

        // DELETE: api/university/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound("University not found");

            return Ok("Deleted successfully");
        }

    }
}
