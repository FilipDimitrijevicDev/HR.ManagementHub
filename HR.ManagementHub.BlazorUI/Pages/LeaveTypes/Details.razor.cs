using HR.ManagementHub.BlazorUI.Common.Interfaces;
using HR.ManagementHub.BlazorUI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.ManagementHub.BlazorUI.Pages.LeaveTypes;

public partial class Details
{
    [Inject]
    ILeaveTypeService _client { get; set; }

    [Parameter]
    public Guid uid { get; set; }

    LeaveTypeVM leaveType = new LeaveTypeVM();

    protected async override Task OnParametersSetAsync()
    {
        leaveType = await _client.GetLeaveTypeDetails(uid);
    }
}