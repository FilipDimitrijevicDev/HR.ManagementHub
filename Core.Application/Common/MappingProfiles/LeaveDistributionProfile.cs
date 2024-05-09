using AutoMapper;
using Core.Application.Common.Models.DTOs;

namespace Core.Application.Common.MappingProfiles;

public class LeaveDistributionProfile : Profile
{
    public LeaveDistributionProfile()
    {
        CreateMap<Domain.LeaveDistribution, Models.LeaveDistribution>().ReverseMap();
        CreateMap<LeaveDistributionDto, Models.LeaveDistribution>().ReverseMap();
        CreateMap<Domain.LeaveDistribution, LeaveDistributionDto>();
    }
}
