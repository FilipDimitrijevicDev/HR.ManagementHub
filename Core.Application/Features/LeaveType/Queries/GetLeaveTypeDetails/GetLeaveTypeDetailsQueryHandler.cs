using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Application.Common.Models.DTOs;
using MediatR;

namespace Core.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, GetLeaveTypeDetailsQueryResult>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveRequestRepository;
    private readonly ILogger<GetLeaveTypeDetailsQueryHandler> _logger;

    public GetLeaveTypeDetailsQueryHandler(IMapper mapper,
        ILeaveTypeRepository leaveRequestRepository,
        ILogger<GetLeaveTypeDetailsQueryHandler> logger)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _logger = logger;
    }

    public async Task<GetLeaveTypeDetailsQueryResult> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveRequestRepository.GetByUidAsync(request.Uid);
        if (leaveType == null)
        {
            _logger.LogError("Failed to retrieve leave type: {0}", request.Uid);
            throw new NotFoundException(nameof(LeaveType), request.Uid);
        }

        var result = _mapper.Map<LeaveTypeDetailsDto>(leaveType);
        if (result == null)
        {
            _logger.LogError("Failed to Mapping Leave Type entity to LeaveTypeDTO. LeaveType: {0}", leaveType.Name);
            throw new NotImplementedException();
        }

        return new GetLeaveTypeDetailsQueryResult(result);

    }
}
