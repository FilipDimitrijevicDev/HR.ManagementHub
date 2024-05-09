using AutoMapper;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models.DTOs;
using MediatR;

namespace Core.Application.Features.LeaveDistribution.Queries.GetLeaveDistributions;

public class GetLeaveDistributionsQueryHandler : IRequestHandler<GetLeaveDistributionsQuery, GetLeaveDistributionsQueryResult>
{
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;
    private readonly IMapper _mapper;

    public GetLeaveDistributionsQueryHandler(ILeaveDistributionRepository leaveDistributionRepository, IMapper mapper)
    {
        _leaveDistributionRepository = leaveDistributionRepository;
        _mapper = mapper;
    }
    public async Task<GetLeaveDistributionsQueryResult> Handle(GetLeaveDistributionsQuery request, CancellationToken cancellationToken)
    {
        var leaveDistributions = await _leaveDistributionRepository.GetLeaveDistributionWithDetails();

        var distributions = _mapper.Map<List<LeaveDistributionDto>>(leaveDistributions);

        return new GetLeaveDistributionsQueryResult(distributions);

    }
}
