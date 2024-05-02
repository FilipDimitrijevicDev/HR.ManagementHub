using MediatR;

namespace Core.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommand : IRequest<DeleteLeaveTypeCommandResult>
{
    public Guid Uid { get; set; }
}
