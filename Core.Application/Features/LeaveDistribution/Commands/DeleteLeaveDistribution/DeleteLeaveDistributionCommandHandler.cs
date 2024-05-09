using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using MediatR;

namespace Core.Application.Features.LeaveDistribution.Commands.DeleteLeaveDistribution;

public class DeleteLeaveDistributionCommandHandler : IRequestHandler<DeleteLeaveDistributionCommand, DeleteLeaveDistributionCommandResult>
{
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;
    private readonly IMapper _mapper;

    public DeleteLeaveDistributionCommandHandler(ILeaveDistributionRepository leaveDistributionRepository, IMapper mapper)
    {
        _mapper = mapper;
        _leaveDistributionRepository = leaveDistributionRepository;
    }
    public async Task<DeleteLeaveDistributionCommandResult> Handle(DeleteLeaveDistributionCommand request, CancellationToken cancellationToken)
    {
        var leaveDistributionEntity = await _leaveDistributionRepository.GetByUidAsync(request.Uid);
        if (leaveDistributionEntity == null) 
        {
            throw new NotFoundException(nameof(LeaveDistribution), request.Uid);
        }
        
        await _leaveDistributionRepository.DeleteAsync(leaveDistributionEntity);

        return new DeleteLeaveDistributionCommandResult();
    }
}
