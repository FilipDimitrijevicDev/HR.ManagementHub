using MediatR;

namespace Core.Application.Features.LeaveDistribution.Commands.UpdateLeaveDistribution;

public class UpdateLeaveDistributionCommand : IRequest<UpdateLeaveDistributionCommandResult>
{
    public Guid Uid { get; set; }
    public int NumberOfDays { get; set; }
    public int LeaveTypeUid { get; set; }
    public int Period { get; set; }
}
