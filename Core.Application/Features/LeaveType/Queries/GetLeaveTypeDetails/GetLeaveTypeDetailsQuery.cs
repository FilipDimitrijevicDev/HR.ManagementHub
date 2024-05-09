using MediatR;
namespace Core.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQuery : IRequest<GetLeaveTypeDetailsQueryResult>
{
    public Guid Uid { get; set; }

    public GetLeaveTypeDetailsQuery(Guid uid)
    {
        Uid = uid;
    }    
}
