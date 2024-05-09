using AutoMapper;
using Core.Application.Common.Interfaces;
using MediatR;

namespace Core.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, CreateLeaveTypeCommandResult>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<CreateLeaveTypeCommandResult> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = new Domain.LeaveType
        {
            Uid = Guid.NewGuid(),
            Name = request.Name,
            DefaultDays = request.DefaultDays
        };

        await _leaveTypeRepository.CreateAsync(leaveType);

        return new CreateLeaveTypeCommandResult();
    }
}
