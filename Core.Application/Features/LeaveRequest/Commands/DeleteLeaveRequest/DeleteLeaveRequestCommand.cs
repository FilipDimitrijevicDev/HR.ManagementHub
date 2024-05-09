using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommand : IRequest<DeleteLeaveRequestCommandResult>
{
    public Guid Uid { get; set; }
}
