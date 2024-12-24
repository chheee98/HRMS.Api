using AutoMapper;
using HRMS.Api.Contracts.Auth;
using HRMS.Api.Data.Entities;

namespace HRMS.Api.Mapping;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<UserCreateRequest, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.Ignore());

        CreateMap<User, UserResponse>();
    }
}