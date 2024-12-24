using HRMS.Api.Contracts.Auth;
using HRMS.Api.Contracts.LeaveType;
using HRMS.Api.Data.Entities;
using HRMS.Api.Helpers;
using HRMS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Controllers;

[HrmsAuthorize]
[Route("api/[controller]")]
[ApiController]
public class LeaveTypeController(ILeaveTypeService leaveTypeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Gets()
    {
        return Ok(await leaveTypeService.GetAll());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await leaveTypeService.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LeaveTypeRequest leaveTypeRequest)
    {
        return Ok(await leaveTypeService.Create(leaveTypeRequest));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] LeaveTypeRequest leaveTypeRequest)
    {
        return Ok(await leaveTypeService.Update(id, leaveTypeRequest));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await leaveTypeService.Delete(id);
        return Ok("Leave Type deleted.");
    }
}