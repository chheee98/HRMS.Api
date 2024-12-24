using HRMS.Api.Data.Entities;

namespace HRMS.Api.Contracts.Auth;

public class AuthenticateResponse(User user, string token)
{
    public int Id { get; set; } = user.Id;
    public string FirstName { get; set; } = user.FirstName;
    public string LastName { get; set; } = user.LastName;
    public string Username { get; set; } = user.Username;
    public string Token { get; set; } = token;
}