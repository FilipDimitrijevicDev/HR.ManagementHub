using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, DeleteLeaveRequestCommandResult>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
    {        
        _leaveRequestRepository = leaveRequestRepository;
    }
    public async Task<DeleteLeaveRequestCommandResult> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequestEntity = await _leaveRequestRepository.GetByUidAsync(request.Uid);
        if (leaveRequestEntity == null) 
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Uid);
        }

        await _leaveRequestRepository.DeleteAsync(leaveRequestEntity);
        return new DeleteLeaveRequestCommandResult();
    }
}
