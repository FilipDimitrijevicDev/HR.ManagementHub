using Core.Application.Common.Models.DTOs;

namespace Core.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailsQueryResult
{
    public List<LeaveRequestDetailsDto> LeaveRequestDetailsDto { get; set; }
    public GetLeaveRequestDetailsQueryResult(List<LeaveRequestDetailsDto> leaveRequestDetailsDto)
    {
        LeaveRequestDetailsDto = leaveRequestDetailsDto;
    }
}
