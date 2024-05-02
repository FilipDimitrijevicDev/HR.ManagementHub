using AutoMapper;
using Core.Application.Common.Interfaces;
using MediatR;

namespace Core.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, CreateLeaveTypeCommandResult>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<CreateLeaveTypeCommandResult> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveTypeForAdding = _mapper.Map<Domain.LeaveType>(request);
        if (leaveTypeForAdding == null)
        {
            throw new NotImplementedException();
        }

        await _leaveTypeRepository.CreateAsync(leaveTypeForAdding);

        return new CreateLeaveTypeCommandResult();
    }
}
