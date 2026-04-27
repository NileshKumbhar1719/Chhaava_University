using Departments.Models;
using Departments.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Departments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Depart : ControllerBase
    {
        private readonly IDepartService _service;

        public Depart(IDepartService departService) 
        {

         _service = departService;
        }
        [HttpGet]
        public async Task<IActionResult> getdata()
        {
            var data = await _service.GetDepartmentsAsync();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> create([FromBody] Department department)
        {
            var data= await _service.GetDepartmentsCreateAsync(department);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getbyid(int id )
        {
           var data = await _service.GetDepartmentsByIdAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update([FromBody]Department department,int id)
        {
            
            var result = await _service.GetDepartmentsUpdateAsync(department,id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           
            var result = await _service.DeleteDepartmentsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }
    }
}
