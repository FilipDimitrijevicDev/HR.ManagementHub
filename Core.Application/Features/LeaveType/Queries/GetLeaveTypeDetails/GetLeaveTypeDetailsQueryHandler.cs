using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models;
using MediatR;

namespace Core.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, GetLeaveTypeDetailsQueryResult>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<GetLeaveTypeDetailsQueryResult> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveRequestRepository.GetByUidAsync(request.Uid);
        if (leaveType == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Uid);
        }

        var result = _mapper.Map<LeaveTypeDetailsDto>(leaveType);
        if (result == null)
        {
            throw new NotImplementedException();
        }

        return new GetLeaveTypeDetailsQueryResult(result);

    }
}
