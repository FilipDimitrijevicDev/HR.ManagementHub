using HR.ManagementHub.BlazorUI.Models.LeaveTypes;
using HR.ManagementHub.BlazorUI.Services.Base;

namespace HR.ManagementHub.BlazorUI.Common.Interfaces;

public interface ILeaveTypeService
{
    Task<List<LeaveTypeVM>> GetLeaveTypes();
    Task<LeaveTypeVM> GetLeaveTypeDetails(Guid uid);
    Task<CreateLeaveTypeCommandResult> CreateLeaveType(LeaveTypeVM leaveType);
    Task<Response<Guid>> UpdateLeaveType(Guid uid, LeaveTypeVM leaveType);
    Task<Response<Guid>> DeleteLeaveType(Guid uid);

}
