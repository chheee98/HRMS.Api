namespace HRMS.Api.Data.Entities;

public class LeaveType
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}