using Core.Application.Common.Interfaces;
using FluentValidation;

namespace Core.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(p => p.Uid)
           .NotNull()
           .MustAsync(LeaveTypeMustExist);

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

        RuleFor(p => p.DefaultDays)
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

        _leaveTypeRepository = leaveTypeRepository;
    }

    private async Task<bool> LeaveTypeMustExist(Guid uid, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.GetByUidAsync(uid);
        return leaveType != null;
    }
}
    