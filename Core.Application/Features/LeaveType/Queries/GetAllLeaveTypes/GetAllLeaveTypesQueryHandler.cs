using AutoMapper;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models;
using MediatR;

namespace Core.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetAllLeaveTypesQueryHandler : IRequestHandler<GetAllLeaveTypesQuery, GetAllLeaveTypesQueryResult>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetAllLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<GetAllLeaveTypesQueryResult> Handle(GetAllLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.GetAsync();
        if (leaveTypes == null)
        {
            throw new NotImplementedException();
        }

        var result = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        if (result == null)
        {
            throw new NotImplementedException();
        }

        return new GetAllLeaveTypesQueryResult(result);
    }
}
