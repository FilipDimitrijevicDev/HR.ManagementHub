using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models.DTOs;
using MediatR;

namespace Core.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailsQuery, GetLeaveRequestDetailsQueryResult>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestDetailsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
    }
    public async Task<GetLeaveRequestDetailsQueryResult> Handle(GetLeaveRequestDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveRequestEntity = await _leaveRequestRepository.GetLeaveRequestsWithDetails(request.Uid);
        if (leaveRequestEntity == null) 
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Uid);
        }

        var result = _mapper.Map<List<LeaveRequestDetailsDto>>(leaveRequestEntity);

        return new GetLeaveRequestDetailsQueryResult(result);
    }
}
