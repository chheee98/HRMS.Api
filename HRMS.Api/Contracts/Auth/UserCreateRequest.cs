namespace HRMS.Api.Contracts.Auth;

public class UserCreateRequest
{
    public required string FirstName { get; set; }
    public string LastName { get; set; }
    public required string Username { get; set; }

    public string Password { get; set; }
}