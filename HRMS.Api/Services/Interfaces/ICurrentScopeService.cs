using HRMS.Api.Data.Entities;

namespace HRMS.Api.Services.Interfaces;

public interface ICurrentScopeService
{
    User? CurrentUser { get; }
}