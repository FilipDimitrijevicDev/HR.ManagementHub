using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;

public class CancelLeaveRequestCommand : IRequest<CancelLeaveRequestCommandResult>
{
    public Guid Uid { get; set; }
}
