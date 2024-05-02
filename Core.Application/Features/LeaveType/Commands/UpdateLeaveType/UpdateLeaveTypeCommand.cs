using MediatR;

namespace Core.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommand : IRequest<UpdateLeaveTypeCommandResult>
{
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
