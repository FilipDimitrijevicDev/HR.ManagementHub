using MediatR;

namespace Core.Application.Features.LeaveDistribution.Queries.GetLeaveDistributionDetails;

public class GetLeaveDistributionDetailsQuery : IRequest<GetLeaveDistributionDetailsQueryResult>
{
    public Guid Uid { get; set; }
}
