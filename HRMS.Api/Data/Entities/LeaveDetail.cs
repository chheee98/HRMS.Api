namespace HRMS.Api.Data.Entities;

public class LeaveDetail
{
    public int Id { get; set; }
    public DateTime LeaveDate { get; set; }
    public string Status { get; set; }

    public int LeaveId { get; set; }
    public required Leave Leave { get; set; }
}