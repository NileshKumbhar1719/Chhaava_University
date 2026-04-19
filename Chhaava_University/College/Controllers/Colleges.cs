using College.Models;
using College.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Collegess : ControllerBase
    {
        private readonly ICollegeService _service;

        public Collegess(ICollegeService collegeService)
        {
            _service = collegeService;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            var data = await _service.getall();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Getbyid(int id)
        {
            
            var data = await _service.Getbyid(id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Colleges colleges)
        {
            if(colleges ==null)
            {
                return BadRequest("Invalid data");
            }
            var data = await _service.Create(colleges);

            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody]Colleges colleges,int id)
        {
            if (colleges ==null)
            {
                return BadRequest("Invalid data");
            }
            var data = await _service.Update(colleges);
            if(data == null)
            {
                return BadRequest(data);
            }
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletes(int id )
        {
            var result = await _service.Delete(id);
            if (!result)
            {
                return NotFound("User NotFound");
            }
            return Content(result.ToString());
        }
            

    }
}
