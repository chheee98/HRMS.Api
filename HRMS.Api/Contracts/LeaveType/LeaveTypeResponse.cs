namespace HRMS.Api.Contracts.LeaveType;

public class LeaveTypeResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}