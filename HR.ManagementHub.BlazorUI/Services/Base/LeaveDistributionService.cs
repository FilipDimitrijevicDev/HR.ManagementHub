using Blazored.LocalStorage;
using HR.ManagementHub.BlazorUI.Common.Interfaces;

namespace HR.ManagementHub.BlazorUI.Services.Base;

public class LeaveDistributionService : BaseHttpService, ILeaveDistributionService
{
    public LeaveDistributionService(IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
    {
    }

    public async Task<Response<Guid>> CreateLeaveDistribution(Guid leaveTypeUid)
    {
        try
        {
            var response = new Response<Guid>();
            CreateLeaveDistributionCommand createLeaveDistribution = new() { LeaveTypeUid = leaveTypeUid };

            await _client.LeaveDistributionPOSTAsync(createLeaveDistribution);
            return response;
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
