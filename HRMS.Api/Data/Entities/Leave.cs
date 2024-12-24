namespace HRMS.Api.Data.Entities;

public class Leave
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public required string Reason { get; set; }
    public bool IsApproved { get; set; }

    public int LeaveTypeId { get; set; }
    public required LeaveType LeaveType { get; set; }

    public int EmployeeId { get; set; }
    public required Employee Employee { get; set; }
    
    public required ICollection<LeaveDetail> LeaveDetails { get; set; }
}