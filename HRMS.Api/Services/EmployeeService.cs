using AutoMapper;
using HRMS.Api.Contracts.Employees;
using HRMS.Api.Data;
using HRMS.Api.Data.Entities;
using HRMS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Services;

public class EmployeeService(
    AppDbContext dbContextContext,
    IMapper mapper,
    ILogger<EmployeeService> logger
) : IEmployeeService
{
    public async Task<IEnumerable<EmployeeResponse>> GetAll()
    {
        var employees = await dbContextContext.Employees.ToListAsync();
        return mapper.Map<IEnumerable<EmployeeResponse>>(employees);
    }

    public async Task<EmployeeResponse> GetById(int id)
    {
        var employee = await FindEmployeeAsync(id);

        return mapper.Map<EmployeeResponse>(employee);
    }


    public async Task<EmployeeResponse> Create(EmployeeRequest employeeRequest)
    {
        //Validate Email
        if (await dbContextContext.Employees.AnyAsync(x => x.Email == employeeRequest.Email))
            throw new BadHttpRequestException("Employee Email already exists.");
        
        var employee = mapper.Map<Employee>(employeeRequest);
        var employeeEntry = await dbContextContext.Employees.AddAsync(employee);
        var isSuccess = await dbContextContext.SaveChangesAsync() > 0;
        if (isSuccess)
        {
            return mapper.Map<EmployeeResponse>(employeeEntry.Entity);
        }

        logger.LogError("Failed to create employee.");
        throw new Exception("Failed to create employee.");
    }

    public async Task<EmployeeResponse> Update(int id, EmployeeRequest employeeRequest)
    {
        //Validate Email
        if (await dbContextContext.Employees.AnyAsync(x => x.Id != id && x.Email == employeeRequest.Email))
            throw new BadHttpRequestException("Employee Email already exists.");

        var employee = await FindEmployeeAsync(id);

        employee.FirstName = employeeRequest.FirstName;
        employee.LastName = employeeRequest.LastName;
        employee.Gender = employeeRequest.Gender;
        employee.Email = employeeRequest.Email;
        employee.PhoneNumber = employeeRequest.PhoneNumber;
        employee.DateOfBirth = employeeRequest.DateOfBirth;

        await dbContextContext.SaveChangesAsync();
        return mapper.Map<EmployeeResponse>(employee);
    }

    public async Task Delete(int id)
    {
        await dbContextContext.Employees.Where(
            x => x.Id == id
        ).ExecuteDeleteAsync();
    }

    public async Task ToggleActive(int id)
    {
        var employee = await FindEmployeeAsync(id);
        employee.IsActive = !employee.IsActive;
        await dbContextContext.SaveChangesAsync();
    }

    private async Task<Employee> FindEmployeeAsync(int id)
    {
        var employee = await dbContextContext.Employees.FindAsync(id);
        if (employee == null)
        {
            logger.LogError($"Employee Id: {id} not found");
            throw new KeyNotFoundException("Employee not found");
        }

        return employee;
    }
}