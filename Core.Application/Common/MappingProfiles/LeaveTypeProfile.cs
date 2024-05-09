using AutoMapper;
using Core.Application.Common.Models.DTOs;

namespace Core.Application.Common.MappingProfiles;

public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<Domain.LeaveType, Models.LeaveType>().ReverseMap();
        CreateMap<LeaveTypeDto, Models.LeaveType>().ReverseMap();
        CreateMap<Domain.LeaveType, LeaveTypeDetailsDto>();
        CreateMap<Domain.LeaveType, LeaveTypeDto>();

    }
}
