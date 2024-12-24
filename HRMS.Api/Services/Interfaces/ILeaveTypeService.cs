using HRMS.Api.Contracts.LeaveType;
using HRMS.Api.Data.Entities;

namespace HRMS.Api.Services.Interfaces;

public interface ILeaveTypeService
{
    Task<IEnumerable<LeaveTypeResponse>> GetAll();
    Task<LeaveTypeResponse> GetById(int id);
    Task<LeaveTypeResponse> Create(LeaveTypeRequest leaveType);
    Task<LeaveTypeResponse> Update(int id, LeaveTypeRequest leaveType);
    Task Delete(int id);
}