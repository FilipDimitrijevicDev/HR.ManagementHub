using Core.Application.Common.Models.DTOs;

namespace Core.Application.Features.LeaveDistribution.Queries.GetLeaveDistributionDetails;

public class GetLeaveDistributionDetailsQueryResult
{
    public LeaveDistributionDto LeaveDistributionDto { get; set; }

    public GetLeaveDistributionDetailsQueryResult(LeaveDistributionDto leaveDistributionDto)
    {
        LeaveDistributionDto = leaveDistributionDto;
    }
}
