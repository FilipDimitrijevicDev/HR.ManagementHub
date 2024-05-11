using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Application.Common.Models.DTOs;
using MediatR;

namespace Core.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetAllLeaveTypesQueryHandler : IRequestHandler<GetAllLeaveTypesQuery, GetAllLeaveTypesQueryResult>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllLeaveTypesQueryHandler> _logger;

    public GetAllLeaveTypesQueryHandler(IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository,
        ILogger<GetAllLeaveTypesQueryHandler> logger)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetAllLeaveTypesQueryResult> Handle(GetAllLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.GetAsync();
        if (leaveTypes == null)
        {
            _logger.LogError("Failed to retrieve leave types");
            throw new NotFoundException(nameof(leaveTypes), request);
        }

        var result = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        if (result == null)
        {
            throw new NotImplementedException();
        }

        return new GetAllLeaveTypesQueryResult(result);
    }
}
