namespace HRMS.Api.Contracts.Employees;

public class EmployeeRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Gender { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Position { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public bool IsActive { get; set; } = true;
}