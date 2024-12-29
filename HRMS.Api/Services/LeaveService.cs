using AutoMapper;
using HRMS.Api.Contracts.Leave;
using HRMS.Api.Data;
using HRMS.Api.Data.Entities;
using HRMS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Services;

public class LeaveService(
    AppDbContext dbContextContext,
    IMapper mapper,
    ILogger<EmployeeService> logger
) : ILeaveService
{
    public async Task<IEnumerable<LeaveResponse>> GetAll()
    {
        var leaves = await dbContextContext.Leaves.ToListAsync();
        return mapper.Map<IEnumerable<LeaveResponse>>(leaves);
    }

    public async Task<LeaveResponse> GetById(int id)
    {
        var leave = await FindLeaveAsync(id);
        return mapper.Map<LeaveResponse>(leave);
    }

    public async Task<LeaveResponse> Create(LeaveCreateRequest leaveRequest)
    {
        var leave = mapper.Map<Leave>(leaveRequest);
        await dbContextContext.Leaves.AddAsync(leave);

        var isSuccess = await dbContextContext.SaveChangesAsync() > 0;
        if (isSuccess)
        {
            return mapper.Map<LeaveResponse>(leave);
        }

        logger.LogError("Failed to create leave.");
        throw new Exception("Failed to create leave.");
    }

    public async Task<LeaveResponse> Update(int id, LeaveUpdateRequest leaveRequest)
    {
        var leave = await FindLeaveAsync(id);
        mapper.Map(leaveRequest, leave);
        await dbContextContext.SaveChangesAsync();

        return mapper.Map<LeaveResponse>(leave);
    }


    public async Task Delete(int id)
    {
        await dbContextContext.Leaves.Where(
            x => x.Id == id
        ).ExecuteDeleteAsync();
    }

    private async Task<Leave> FindLeaveAsync(int id)
    {
        var leave = await dbContextContext.Leaves
            .Include(l => l.LeaveDetails)
            .Include(l => l.LeaveType)
            .Include(l => l.Employee)
            .FirstOrDefaultAsync(l => l.Id == id);
        
        if (leave == null)
        {
            logger.LogError($"Leave Id: {id} not found");
            throw new KeyNotFoundException("Leave not found");
        }

        return leave;
    }
}