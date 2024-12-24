using HRMS.Api.Services;
using HRMS.Api.Services.Interfaces;
using Microsoft.OpenApi.Models;

namespace HRMS.Api.Extensions;

public static class RepositoryServiceCollectionsExtensions
{
    public static IServiceCollection AddAppRepository(this IServiceCollection services)
    {

        return services;
    }
}