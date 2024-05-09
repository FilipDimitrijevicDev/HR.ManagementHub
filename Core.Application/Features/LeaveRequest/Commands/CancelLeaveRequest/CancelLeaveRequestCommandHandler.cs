using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;

public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, CancelLeaveRequestCommandResult>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    public CancelLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
    }
    public async Task<CancelLeaveRequestCommandResult> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequestEntity = await _leaveRequestRepository.GetByUidAsync(request.Uid);
        if (leaveRequestEntity == null) 
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Uid);
        }

        leaveRequestEntity.Cancelled = true;
        
        await _leaveRequestRepository.UpdateAsync(leaveRequestEntity);

        //TODO: Here needs logic for if request is Approved to recalculate days and back to employee his days

        return new CancelLeaveRequestCommandResult();
    }
}
