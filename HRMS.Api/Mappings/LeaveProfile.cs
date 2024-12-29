using AutoMapper;
using HRMS.Api.Contracts.Leave;
using HRMS.Api.Data.Entities;

namespace HRMS.Api.Mappings;

public class LeaveProfile : Profile
{
    public LeaveProfile()
    {
        CreateMap<LeaveCreateRequest, Leave>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<LeaveDetailCreateRequest, LeaveDetail>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<LeaveUpdateRequest, Leave>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<LeaveDetailUpdateRequest, LeaveDetail>();

        CreateMap<Leave, LeaveResponse>()
            .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => src.Employee.FullName))
            .ForMember(dest => dest.LeaveTypeName, opt => opt.MapFrom(src => src.LeaveType.Name));
        CreateMap<LeaveDetail, LeaveDetailResponse>();
    }
}