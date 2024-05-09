using FluentValidation;

namespace Core.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailsQueryValidator : AbstractValidator<GetLeaveRequestDetailsQuery>
{
    public GetLeaveRequestDetailsQueryValidator()
    {
        RuleFor(p => p.Uid)
            .NotNull()
            .NotEmpty();
    }
}
