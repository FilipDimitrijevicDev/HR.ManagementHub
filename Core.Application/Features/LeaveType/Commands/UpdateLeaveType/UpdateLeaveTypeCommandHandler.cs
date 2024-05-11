using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using MediatR;

namespace Core.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, UpdateLeaveTypeCommandResult>
{
    private readonly ILogger<UpdateLeaveTypeCommandHandler> _logger;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandHandler(ILogger<UpdateLeaveTypeCommandHandler> logger, ILeaveTypeRepository leaveTypeRepository)
    {
        _logger = logger;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<UpdateLeaveTypeCommandResult> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveTypeEntity = await _leaveTypeRepository.GetByUidAsync(request.Uid);
        if (leaveTypeEntity == null)
        {
            _logger.LogError($"Leave Type with UID: {0} doesn't exist", request.Uid);

            throw new NotFoundException(nameof(LeaveType), request.Uid);
        }

        leaveTypeEntity.Name = request.Name;
        leaveTypeEntity.DefaultDays = request.DefaultDays;

        await _leaveTypeRepository.UpdateAsync(leaveTypeEntity);

        return new UpdateLeaveTypeCommandResult();
    }
}
