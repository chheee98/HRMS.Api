using HRMS.Api.Contracts.Auth;
using HRMS.Api.Data.Entities;
using HRMS.Api.Helpers;
using HRMS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Controllers;

[HrmsAuthorize]
[Route("api/[controller]")]
[ApiController]
public class LeaveController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Gets()
    {
        await Task.Delay(1000);
        return Ok(" list");
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        await Task.Delay(1000);
        return Ok(" retrieve");
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Employee employee)
    {
        await Task.Delay(1000);
        return Ok(" create");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] Employee employee)
    {
        await Task.Delay(1000);
        return Ok(" update");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await Task.Delay(1000);
        return Ok(" delete");
    }
}