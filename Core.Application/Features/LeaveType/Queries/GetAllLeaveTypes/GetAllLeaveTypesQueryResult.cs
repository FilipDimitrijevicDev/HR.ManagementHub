using Core.Application.Common.Models.DTOs;
namespace Core.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetAllLeaveTypesQueryResult
{
    public List<LeaveTypeDto> LeaveTypeDto { get; set; }
    public GetAllLeaveTypesQueryResult(List<LeaveTypeDto> leaveTypeDto)
    {
        LeaveTypeDto = leaveTypeDto;
    }
}
