using Exam.Models;
using Exams.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace Exams.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _service;

        public ExamController(IExamService examService) 
        {
         _service=examService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetExamsAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetExambyIdAsync(id);
            if (result == null)
            {
                return NotFound("Exam Not Found");
            }
            
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Exampaper exampaper)
        {
            var data = await _service.CreateExame(exampaper);
            return Ok(data);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Exampaper exampaper,int id)
        {
            var data = await _service.UpdateExame(exampaper,id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>delete(int id )
        {
            var data = await _service.DeleteExamAsync(id);
            if(data==null)
            {
                return NotFound("user not found");
            }
            return Ok("user deleted successfully ");
        }
    }
}
