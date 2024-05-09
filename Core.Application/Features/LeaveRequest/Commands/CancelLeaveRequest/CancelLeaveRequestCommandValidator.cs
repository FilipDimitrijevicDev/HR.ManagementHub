using FluentValidation;

namespace Core.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;

public class CancelLeaveRequestCommandValidator : AbstractValidator<CancelLeaveRequestCommand>
{
    public CancelLeaveRequestCommandValidator()
    {
        RuleFor(x => x.Uid)
            .NotNull()
            .NotEmpty();
    }
}
