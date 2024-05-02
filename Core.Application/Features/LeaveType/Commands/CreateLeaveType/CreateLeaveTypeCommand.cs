using MediatR;

namespace Core.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommand : IRequest<CreateLeaveTypeCommandResult>
{
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
