using Core.Application.Common.Models.DTOs;

namespace Core.Application.Features.LeaveDistribution.Queries.GetLeaveDistributions;

public class GetLeaveDistributionsQueryResult
{
    public List<LeaveDistributionDto> LeaveDistributionDtos { get; set; }

    public GetLeaveDistributionsQueryResult(List<LeaveDistributionDto> leaveDistributionDtos)
    {
        LeaveDistributionDtos = leaveDistributionDtos;
    }
}
