using HRMS.Api.Contracts.Auth;
using HRMS.Api.Data;
using HRMS.Api.Data.Entities;
using HRMS.Api.Models;
using HRMS.Api.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Services;

public class UserService(
    IOptions<AppSettings> appSettings,
    AppDbContext dbContextContext,
    IMapper mapper,
    ILogger<UserService> logger
)
    : IUserService
{
    public async Task<AuthenticateResponse?> Authenticate(LoginRequest model)
    {
        var user = await dbContextContext.Users.FirstOrDefaultAsync(
            x => x.Username == model.Username && x.Password == model.Password);

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = await GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await dbContextContext.Users.Where(x => x.IsActive == true).ToListAsync();
    }

    public async Task<User?> GetById(int id)
    {
        return await dbContextContext.Users.FindAsync(id);
    }

    public async Task<UserResponse?> Create(UserCreateRequest request)
    {
        var user = mapper.Map<User>(request);
        user.IsActive = true;
        await dbContextContext.Users.AddAsync(user);
        var isSuccess = await dbContextContext.SaveChangesAsync() > 0;

        return !isSuccess
            ? null
            : mapper.Map<UserResponse>(user);
    }

    public async Task<UserResponse?> Update(int id, UserUpdateRequest request)
    {
        var user = await dbContextContext.Users.FindAsync(id);
        if (user == null)
            throw new KeyNotFoundException("User not found");

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        dbContextContext.Users.Update(user);
        var isSuccess = await dbContextContext.SaveChangesAsync() > 0;

        return !isSuccess
            ? null
            : mapper.Map<UserResponse>(user);
    }

    // helper methods
    private async Task<string> GenerateJwtToken(User user)
    {
        //Generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = await Task.Run(() =>
        {
            // Ensure the key is at least 256 bits (32 bytes)
            var secret = appSettings.Value.Secret;
            var key = Encoding.ASCII.GetBytes(secret.PadRight(32).Substring(0, 32)); // Pad or truncate to 32 bytes

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.CreateToken(tokenDescriptor);
        });

        return tokenHandler.WriteToken(token);
    }
}