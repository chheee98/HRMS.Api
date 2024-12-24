using HRMS.Api.Contracts.Employees;

namespace HRMS.Api.Services.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeResponse>> GetAll();
    Task<EmployeeResponse> GetById(int id);
    Task<EmployeeResponse> Create(EmployeeRequest employee);
    Task<EmployeeResponse> Update(int id, EmployeeRequest employee);
    Task Delete(int id);
    
    Task ToggleActive(int id);
}