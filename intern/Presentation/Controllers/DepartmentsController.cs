using Business.Dtos;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentPostDto dto)
        {
            return Ok(await _departmentService.CreateAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(DepartmentPutDto dto)
        {
            return Ok(await _departmentService.UpdateAsync(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _departmentService.DeleteAsync(id));
        }
    }

}
