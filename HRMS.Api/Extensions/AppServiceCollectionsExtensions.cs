using HRMS.Api.Services;
using HRMS.Api.Services.Interfaces;
using Microsoft.OpenApi.Models;

namespace HRMS.Api.Extensions;

public static class AppServiceCollectionsExtensions
{
    public static IServiceCollection AddAppService(this IServiceCollection services)
    {
        services.AddScoped<ICurrentScopeService, CurrentScopeService>();
        services.AddScoped<IUserService, UserService>();
        
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ILeaveTypeService, LeaveTypeService>();

        return services;
    }
}