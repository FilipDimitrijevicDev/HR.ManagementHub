using Core.Application.Common.Interfaces;
using FluentValidation;

namespace Core.Application.Features.LeaveDistribution.Commands.UpdateLeaveDistribution;

public class UpdateLeaveDistributionCommandValidator : AbstractValidator<UpdateLeaveDistributionCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;
    public UpdateLeaveDistributionCommandValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveDistributionRepository leaveDistributionRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _leaveDistributionRepository = leaveDistributionRepository;

        RuleFor(p => p.NumberOfDays)
            .GreaterThan(0).WithMessage("{PropertyName} must greater than {ComparisonValue}");

        RuleFor(p => p.Period)
            .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

        RuleFor(p => p.Uid)
            .NotNull()
            .NotEmpty()
            .MustAsync(LeaveTypeMustExist)
            .WithMessage("{PropertyName} does not exist.");

        RuleFor(p => p.Uid)
            .NotNull()
            .NotEmpty()
            .MustAsync(LeaveDistributionMustExist)
            .WithMessage("{PropertyName} must be present");
    }
    private async Task<bool> LeaveDistributionMustExist(Guid uid, CancellationToken arg2)
    {
        var leaveDistribution = await _leaveDistributionRepository.GetByUidAsync(uid);
        return leaveDistribution != null;
    }

    private async Task<bool> LeaveTypeMustExist(Guid uid, CancellationToken arg2)
    {
        var leaveType = await _leaveTypeRepository.GetByUidAsync(uid);
        return leaveType != null;
    }
}
