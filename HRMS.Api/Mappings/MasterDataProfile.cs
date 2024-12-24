using AutoMapper;
using HRMS.Api.Contracts.Employees;
using HRMS.Api.Contracts.LeaveType;
using HRMS.Api.Data.Entities;

namespace HRMS.Api.Mappings;

public class MasterDataProfile : Profile
{
    public MasterDataProfile()
    {
        
        // Employee mapper
        CreateMap<EmployeeRequest, Employee>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Employee, EmployeeResponse>();
        
        // LeaveType mapper
        CreateMap<LeaveTypeRequest, LeaveType>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        
        CreateMap<LeaveType, LeaveTypeResponse>();
    }
}