using AutoMapper;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models.DTOs;
using MediatR;

namespace Core.Application.Features.LeaveRequest.Queries.GetLeaveRequests;

public class GetLeaveRequestsQueryHandler : IRequestHandler<GetLeaveRequestsQuery, GetLeaveRequestsQueryResult>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    public GetLeaveRequestsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;   
    }
    public async Task<GetLeaveRequestsQueryResult> Handle(GetLeaveRequestsQuery request, CancellationToken cancellationToken)
    {
        var leaveRequestsEntity = await _leaveRequestRepository.GetLeaveRequestsWithDetails();

        var result = _mapper.Map<LeaveRequestListDto>(leaveRequestsEntity);

        return new GetLeaveRequestsQueryResult(result);
    }
}
