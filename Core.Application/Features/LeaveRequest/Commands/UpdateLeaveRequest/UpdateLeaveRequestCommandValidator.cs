using FluentValidation;

namespace Core.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
{
    public UpdateLeaveRequestCommandValidator()
    {
        RuleFor(x => x.Uid)
        .NotNull()
        .NotEmpty();
    }
}
