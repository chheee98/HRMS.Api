using HRMS.Api.Contracts.Auth;
using HRMS.Api.Contracts.Leave;
using HRMS.Api.Data.Entities;
using HRMS.Api.Helpers;
using HRMS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Controllers;

[HrmsAuthorize]
[Route("api/[controller]")]
[ApiController]
public class LeaveController(ILeaveService leaveService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Gets()
    {
        return Ok(await leaveService.GetAll());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await leaveService.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LeaveCreateRequest leaveRequest)
    {
        return Ok(await leaveService.Create(leaveRequest));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] LeaveUpdateRequest leaveRequest)
    {
        return Ok(await leaveService.Update(id, leaveRequest));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await leaveService.Delete(id);
        return Ok("Leave deleted");
    }
}