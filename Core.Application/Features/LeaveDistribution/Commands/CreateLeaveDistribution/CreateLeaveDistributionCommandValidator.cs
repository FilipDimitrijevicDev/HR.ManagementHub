using Core.Application.Common.Interfaces;
using FluentValidation;

namespace Core.Application.Features.LeaveDistribution.Commands.CreateLeaveDistribution;

public class CreateLeaveDistributionCommandValidator : AbstractValidator<CreateLeaveDistributionCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveDistributionCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.LeaveTypeUid)
                .NotEmpty()
                .NotNull()
                .MustAsync(LeaveTypeMustExist)
                .WithMessage("{PropertyName} does not exist.");
    }

    private async Task<bool> LeaveTypeMustExist(Guid uid, CancellationToken arg2)
    {
        var leaveType = await _leaveTypeRepository.GetByUidAsync(uid);
        return leaveType != null;
    }
}
