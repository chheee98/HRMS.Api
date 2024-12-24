using System.ComponentModel.DataAnnotations;

namespace HRMS.Api.Contracts.Auth;

public class UserResponse
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    public required string Username { get; set; }

    public bool IsActive { get; set; }
}