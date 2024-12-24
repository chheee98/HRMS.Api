using AutoMapper;
using HRMS.Api.Contracts.LeaveType;
using HRMS.Api.Data;
using HRMS.Api.Data.Entities;
using HRMS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Services;

public class LeaveTypeService(
    AppDbContext dbContextContext,
    IMapper mapper,
    ILogger<LeaveTypeService> logger
) : ILeaveTypeService
{
    public async Task<IEnumerable<LeaveTypeResponse>> GetAll()
    {
        return mapper.Map<List<LeaveTypeResponse>>(await dbContextContext.LeaveTypes.ToListAsync());
    }

    public async Task<LeaveTypeResponse> GetById(int id)
    {
        var leaveType = await FindLeaveTypeAsync(id);
        return mapper.Map<LeaveTypeResponse>(leaveType);
    }

    public async Task<LeaveTypeResponse> Create(LeaveTypeRequest leaveTypeRequest)
    {
        //Validate Unique Name
        if (await dbContextContext.LeaveTypes.AnyAsync(x => x.Name == leaveTypeRequest.Name))
            throw new BadHttpRequestException($"{leaveTypeRequest.Name} already exists");

        var leaveType = mapper.Map<LeaveType>(leaveTypeRequest);
        var leaveTypeEntry = await dbContextContext.LeaveTypes.AddAsync(leaveType);

        var isSuccess = await dbContextContext.SaveChangesAsync() > 0;
        if (isSuccess)
        {
            return mapper.Map<LeaveTypeResponse>(leaveTypeEntry.Entity);
        }

        logger.LogError("Failed to create Leave Type.");
        throw new Exception("Failed to create Leave Type.");
    }

    public async Task<LeaveTypeResponse> Update(int id, LeaveTypeRequest leaveTypeRequest)
    {
        //Validate Unique Name
        if (await dbContextContext.LeaveTypes.AnyAsync(x => x.Id != id && x.Name == leaveTypeRequest.Name))
            throw new BadHttpRequestException($"{leaveTypeRequest.Name} already exists");

        var leaveType = await FindLeaveTypeAsync(id);

        leaveType.Name = leaveTypeRequest.Name;
        leaveType.Description = leaveTypeRequest.Description;
        var isSuccess = await dbContextContext.SaveChangesAsync() > 0;
        if (isSuccess)
        {
            return mapper.Map<LeaveTypeResponse>(leaveType);
        }

        logger.LogError($"Failed to update Leave Type Id: {id}.");
        throw new Exception("Failed to update Leave Type.");
    }

    public async Task Delete(int id)
    {
        await dbContextContext.LeaveTypes.Where(x => x.Id == id).ExecuteDeleteAsync();
    }


    private async Task<LeaveType> FindLeaveTypeAsync(int id)
    {
        var leaveType = await dbContextContext.LeaveTypes.FindAsync(id);
        if (leaveType == null)
        {
            logger.LogError($"LeaveType Id: {id} not found");
            throw new KeyNotFoundException("Leave not found");
        }

        return leaveType;
    }
}