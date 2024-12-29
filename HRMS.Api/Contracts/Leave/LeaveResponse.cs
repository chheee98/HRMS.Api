namespace HRMS.Api.Contracts.Leave;

public class LeaveResponse
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public required string Reason { get; set; }
    public bool IsApproved { get; set; }

    public int LeaveTypeId { get; set; }
    public required string LeaveTypeName { get; set; }

    public int EmployeeId { get; set; }
    public required string EmployeeFullName { get; set; }

    public required List<LeaveDetailResponse> LeaveDetails { get; set; } = [];
}

public class LeaveDetailResponse
{
    public int Id { get; set; }
    public DateTime LeaveDate { get; set; }
    public string Status { get; set; }
}