using AutoMapper;
using Core.Application.Common.Interfaces;
using MediatR;

namespace Core.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, UpdateLeaveTypeCommandResult>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<UpdateLeaveTypeCommandResult> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveTypeForUpdate = _mapper.Map<Domain.LeaveType>(request);
        if (leaveTypeForUpdate == null)
        {
            throw new NotImplementedException();
        }

        await _leaveTypeRepository.UpdateAsync(leaveTypeForUpdate);

        return new UpdateLeaveTypeCommandResult();
    }
}
