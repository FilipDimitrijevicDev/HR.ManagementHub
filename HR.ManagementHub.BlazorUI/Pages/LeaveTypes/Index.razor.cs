using HR.ManagementHub.BlazorUI.Common.Interfaces;
using HR.ManagementHub.BlazorUI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.ManagementHub.BlazorUI.Pages.LeaveTypes;

public partial class Index
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ILeaveTypeService LeaveTypeService { get; set; }
    [Inject]
    public ILeaveDistributionService LeaveDistributionService { get; set; }
    //[Inject]
    //IToastService toastService { get; set; }

    public List<LeaveTypeVM> LeaveTypes { get; private set; }
    public string Message { get; set; } = string.Empty;

    protected void CreateLeaveType()
    {
        NavigationManager.NavigateTo("/leavetypes/create/");
    }

    protected void AssignLeaveType(Guid uid)
    {
        LeaveDistributionService.CreateLeaveDistribution(uid);
    }

    protected void EditLeaveType(Guid uid)
    {
        NavigationManager.NavigateTo($"/leavetypes/edit/{uid}");
    }

    protected void DetailsLeaveType(Guid uid)
    {
        NavigationManager.NavigateTo($"/leavetypes/details/{uid}");
    }

    protected async Task DeleteLeaveType(Guid uid)
    {
        var response = await LeaveTypeService.DeleteLeaveType(uid);
        if (response.Success)
        {
            //toastService.ShowSuccess("Leave Type deleted Successfully");
            await OnInitializedAsync();
        }
        else
        {
            Message = response.Message;
        }
    }

    protected override async Task OnInitializedAsync()
    {
        var result = await LeaveTypeService.GetLeaveTypes();
        LeaveTypes = result;
    }
}
