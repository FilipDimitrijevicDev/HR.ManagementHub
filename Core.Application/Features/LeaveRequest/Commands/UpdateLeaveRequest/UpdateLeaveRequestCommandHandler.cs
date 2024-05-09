using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, UpdateLeaveRequestCommandResult>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
    }
    public async Task<UpdateLeaveRequestCommandResult> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequestEntity = await _leaveRequestRepository.GetByUidAsync(request.Uid);
        if (leaveRequestEntity == null) 
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Uid);
        }

        var leaveRequest = _mapper.Map<Common.Models.LeaveRequest>(leaveRequestEntity);

        leaveRequest.Comments = request.Comments;
        leaveRequest.StartDate = request.StartDate;
        leaveRequest.EndDate = request.EndDate;
        leaveRequest.LeaveType.Uid = request.LeaveTypeUid;

        var result = _mapper.Map<Domain.LeaveRequest>(leaveRequest);

        await _leaveRequestRepository.UpdateAsync(result);

        return new UpdateLeaveRequestCommandResult();
    }
}