using Blazored.LocalStorage;
using HR.ManagementHub.BlazorUI.Common.Interfaces;

namespace HR.ManagementHub.BlazorUI.Services.Base;

public class LeaveRequestService : BaseHttpService, ILeaveRequestService
{
    public LeaveRequestService(IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
    {
    }
}
