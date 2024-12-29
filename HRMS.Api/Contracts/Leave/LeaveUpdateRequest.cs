namespace HRMS.Api.Contracts.Leave;

public class LeaveUpdateRequest
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; }
    public bool IsApproved { get; set; }
    public int LeaveTypeId { get; set; }
    public List<LeaveDetailUpdateRequest> LeaveDetails { get; set; } = [];
}

public class LeaveDetailUpdateRequest
{
    public int Id { get; set; } // Required to identify the detail being updated
    public DateTime LeaveDate { get; set; }
    public string Status { get; set; }
}