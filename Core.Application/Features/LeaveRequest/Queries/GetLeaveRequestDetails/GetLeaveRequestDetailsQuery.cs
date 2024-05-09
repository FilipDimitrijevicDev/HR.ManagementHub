using MediatR;

namespace Core.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailsQuery : IRequest<GetLeaveRequestDetailsQueryResult>
{
    public Guid Uid { get; set; }
}
