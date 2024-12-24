using HRMS.Api.Contracts.Auth;
using HRMS.Api.Helpers;
using HRMS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Authenticate(LoginRequest request)
    {
        var response = await userService.Authenticate(request);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    // POST api/Users
    [HttpPost]
    [HrmsAuthorize]
    public async Task<IActionResult> Post([FromBody] UserCreateRequest userRequest)
    {
        return Ok(await userService.Create(userRequest));
    }

    // PUT api/Users/5
    [HttpPut("{id:int}")]
    [HrmsAuthorize]
    public async Task<IActionResult> Put(int id, [FromBody] UserUpdateRequest userRequest)
    {
        return Ok(await userService.Update(id, userRequest));
    }
}