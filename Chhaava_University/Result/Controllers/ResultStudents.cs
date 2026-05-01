using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Result.Models;
using Result.Service;

namespace Result.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultStudents : ControllerBase
    {
        private readonly IResultService _Service;

        public ResultStudents(IResultService service) 
        {
          _Service=service;
        }
        [HttpGet]
        public async Task<IActionResult> gellResutAll()
        {
            var result= await _Service.GetAllStudentsResult();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdByResult(int id)
        {
            var data = await _Service.GetByIdStudentsResult(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult>CreateResult(StudentResult resultStudents)
        {
            var result=   await _Service.CreateStudentResult(resultStudents);
            return Ok(result);

             
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateResult(StudentResult  studentResult ,int id )
        {
            var result = await _Service.UpdateStudentResult(studentResult,id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResult(int id)
        {
            var result = await _Service.DeleteStudentResult(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
