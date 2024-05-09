using MediatR;

namespace Core.Application.Features.LeaveDistribution.Commands.UpdateLeaveDistribution;

public class UpdateLeaveDistributionCommandHandler : IRequestHandler<UpdateLeaveDistributionCommand, UpdateLeaveDistributionCommandResult>
{
    public Task<UpdateLeaveDistributionCommandResult> Handle(UpdateLeaveDistributionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
