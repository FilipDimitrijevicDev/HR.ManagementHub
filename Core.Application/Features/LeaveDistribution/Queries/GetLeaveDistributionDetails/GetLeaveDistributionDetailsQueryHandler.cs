using AutoMapper;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models.DTOs;
using MediatR;

namespace Core.Application.Features.LeaveDistribution.Queries.GetLeaveDistributionDetails;

public class GetLeaveDistributionDetailsQueryHandler : IRequestHandler<GetLeaveDistributionDetailsQuery, GetLeaveDistributionDetailsQueryResult>
{
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;
    private readonly IMapper _mapper;

    public GetLeaveDistributionDetailsQueryHandler(ILeaveDistributionRepository leaveDistributionRepository, IMapper mapper)
    {
        _leaveDistributionRepository = leaveDistributionRepository;
        _mapper = mapper;
    }

    public async Task<GetLeaveDistributionDetailsQueryResult> Handle(GetLeaveDistributionDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveDistributionEntity = await _leaveDistributionRepository.GetLeaveDistributionWithDetails(request.Uid);

        var leaveDistribution = _mapper.Map<LeaveDistributionDto>(leaveDistributionEntity);

        return new GetLeaveDistributionDetailsQueryResult(leaveDistribution);
    }
}
