using HR.ManagementHub.BlazorUI.Common.Interfaces;
using HR.ManagementHub.BlazorUI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.ManagementHub.BlazorUI.Pages.LeaveTypes;

public partial class Edit
{
    [Inject]
    ILeaveTypeService _client { get; set; }

    [Inject]
    NavigationManager _navManager { get; set; }

    [Parameter]
    public Guid uid { get; set; }
    public string Message { get; private set; }

    LeaveTypeVM leaveType = new LeaveTypeVM();

    protected async override Task OnParametersSetAsync()
    {
        leaveType = await _client.GetLeaveTypeDetails(uid);
    }

    async Task EditLeaveType()
    {
        var response = await _client.UpdateLeaveType(uid, leaveType);
        if (response.Success)
        {
            _navManager.NavigateTo("/leavetypes/");
        }
        Message = response.Message;
    }
}