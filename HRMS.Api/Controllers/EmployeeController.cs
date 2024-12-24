using HRMS.Api.Contracts.Auth;
using HRMS.Api.Contracts.Employees;
using HRMS.Api.Helpers;
using HRMS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Controllers;

[HrmsAuthorize]
[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Gets()
    {
        return Ok(await employeeService.GetAll());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await employeeService.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EmployeeRequest employee)
    {
        return Ok(await employeeService.Create(employee));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] EmployeeRequest employee)
    {
        return Ok(await employeeService.Update(id, employee));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await employeeService.Delete(id);
        return Ok("Employee deleted");
    }
    
    [HttpPut("toggleActive/{id:int}")]
    public async Task<IActionResult> ActiveEmployee(int id)
    {
        await employeeService.ToggleActive(id);
        return Ok(await employeeService.GetById(id));
    }
}