using System.ComponentModel.DataAnnotations;

namespace HRMS.Api.Contracts.Auth;

public class UserUpdateRequest
{
    [Required]
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
}