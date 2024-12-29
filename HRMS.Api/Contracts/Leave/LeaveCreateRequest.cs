namespace HRMS.Api.Contracts.Leave;

public class LeaveCreateRequest
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public required string Reason { get; set; }
    public int LeaveTypeId { get; set; }
    public int EmployeeId { get; set; }
    public List<LeaveDetailCreateRequest> LeaveDetails { get; set; } = [];
}

public class LeaveDetailCreateRequest
{
    public DateTime LeaveDate { get; set; }
    public string Status { get; set; } = "Pending"; // Default status
}