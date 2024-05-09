using MediatR;

namespace Core.Application.Features.LeaveDistribution.Commands.CreateLeaveDistribution;

public class CreateLeaveDistributionCommand : IRequest<CreateLeaveDistributionCommandResult>
{
    public Guid LeaveTypeUid { get; set; }
}
