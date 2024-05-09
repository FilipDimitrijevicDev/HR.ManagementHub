using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using MediatR;

namespace Core.Application.Features.LeaveDistribution.Commands.UpdateLeaveDistribution;

public class UpdateLeaveDistributionCommandHandler : IRequestHandler<UpdateLeaveDistributionCommand, UpdateLeaveDistributionCommandResult>
{
    private readonly IMapper _mapper;
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;


    public UpdateLeaveDistributionCommandHandler(IMapper mapper, ILeaveDistributionRepository leaveDistributionRepository)
    {
        _leaveDistributionRepository = leaveDistributionRepository;
        _mapper = mapper;
    }
    public async Task<UpdateLeaveDistributionCommandResult> Handle(UpdateLeaveDistributionCommand request, CancellationToken cancellationToken)
    {
        var leaveDistributionEntity = await _leaveDistributionRepository.GetByUidAsync(request.Uid);
        if (leaveDistributionEntity == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Uid);
        }

        leaveDistributionEntity.NumberOfDays = request.NumberOfDays;
        leaveDistributionEntity.LeaveTypeId = request.LeaveTypeId;
        leaveDistributionEntity.Period = request.Period;

        await _leaveDistributionRepository.UpdateAsync(leaveDistributionEntity);

        return new UpdateLeaveDistributionCommandResult();
    }
}
