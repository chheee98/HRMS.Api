using HRMS.Api.Data.Entities;
using HRMS.Api.Services.Interfaces;

namespace HRMS.Api.Services;

public class CurrentScopeService(IHttpContextAccessor httpContextAccessor) : ICurrentScopeService
{
    public User? CurrentUser
    {
        get
        {
            if (httpContextAccessor.HttpContext == null)
                return null;

            if (httpContextAccessor.HttpContext.Items.TryGetValue("User", out var userObj) && userObj is User user)
            {
                return user;
            }

            return null;
        }
    }
}