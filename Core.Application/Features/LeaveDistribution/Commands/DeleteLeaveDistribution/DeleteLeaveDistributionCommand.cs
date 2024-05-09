using MediatR;

namespace Core.Application.Features.LeaveDistribution.Commands.DeleteLeaveDistribution;

public class DeleteLeaveDistributionCommand : IRequest<DeleteLeaveDistributionCommandResult>
{
    public Guid Uid { get; set; }
}
