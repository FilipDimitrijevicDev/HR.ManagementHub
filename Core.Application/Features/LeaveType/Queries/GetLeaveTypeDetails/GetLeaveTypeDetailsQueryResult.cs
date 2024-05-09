using Core.Application.Common.Models.DTOs;
namespace Core.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryResult
{
    public LeaveTypeDetailsDto LeaveTypeDetailsDto { get; set; }

    public GetLeaveTypeDetailsQueryResult(LeaveTypeDetailsDto leaveTypeDetailsDto)
    {
        LeaveTypeDetailsDto = leaveTypeDetailsDto;
    }
}
