using Core.Application.Common.Models.DTOs;

namespace Core.Application.Features.LeaveRequest.Queries.GetLeaveRequests;

public class GetLeaveRequestsQueryResult
{
    public LeaveRequestListDto LeaveRequestListDto { get; set; }

    public GetLeaveRequestsQueryResult(LeaveRequestListDto leaveRequestListDto)
    {
        LeaveRequestListDto = leaveRequestListDto;
    }
}
