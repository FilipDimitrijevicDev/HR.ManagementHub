using AutoMapper;
using Core.Application.Common.Interfaces;
using MediatR;

namespace Core.Application.Features.LeaveDistribution.Commands.CreateLeaveDistribution;

public class CreateLeaveDistributionCommandHandler : IRequestHandler<CreateLeaveDistributionCommand, CreateLeaveDistributionCommandResult>
{
    private readonly IMapper _mapper;
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveDistributionCommandHandler(IMapper mapper, ILeaveDistributionRepository leaveDistributionRepository, ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveDistributionRepository = leaveDistributionRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }


    public Task<CreateLeaveDistributionCommandResult> Handle(CreateLeaveDistributionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
