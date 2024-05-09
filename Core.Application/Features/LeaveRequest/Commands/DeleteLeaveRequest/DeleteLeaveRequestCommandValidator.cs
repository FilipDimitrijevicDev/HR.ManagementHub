using FluentValidation;

namespace Core.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommandValidator : AbstractValidator<DeleteLeaveRequestCommand>
{
    public DeleteLeaveRequestCommandValidator()
    {
        RuleFor(x => x.Uid)
            .NotNull()
            .NotEmpty();
    }
}
