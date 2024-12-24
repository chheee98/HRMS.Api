using HRMS.Api.Data.Entities;
using HRMS.Api.Contracts.Auth;

namespace HRMS.Api.Services.Interfaces;

public interface IUserService
{
    Task<AuthenticateResponse?> Authenticate(LoginRequest model);
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(int id);
    Task<UserResponse?> Create(UserCreateRequest request);
    Task<UserResponse?> Update(int id, UserUpdateRequest request);
}