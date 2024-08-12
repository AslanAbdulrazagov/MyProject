using Business.Dtos;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    [HttpPost]

    public async Task<IActionResult> Create(EmployeePostDto dto)
    {

        return Ok(await _employeeService.CreateAsync(dto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(EmployeePutDto dto)
    {
        return Ok(await _employeeService.UpdateAsync(dto));
    }
    [HttpGet]
    [Authorize(Roles ="Admin")]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _employeeService.GetAllAsync();

        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var employee = await _employeeService.GetByIdAsync(id);

        return Ok(employee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _employeeService.DeleteAsync(id));
    }

}
