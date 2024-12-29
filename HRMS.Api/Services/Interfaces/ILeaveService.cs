using HRMS.Api.Contracts.Leave;

namespace HRMS.Api.Services.Interfaces;

public interface ILeaveService
{
    Task<IEnumerable<LeaveResponse>> GetAll();
    Task<LeaveResponse> GetById(int id);
    Task<LeaveResponse> Create(LeaveCreateRequest leaveRequest);
    Task<LeaveResponse> Update(int id, LeaveUpdateRequest leaveRequest);
    Task Delete(int id);
}