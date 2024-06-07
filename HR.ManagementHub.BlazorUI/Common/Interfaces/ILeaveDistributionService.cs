using HR.ManagementHub.BlazorUI.Services.Base;

namespace HR.ManagementHub.BlazorUI.Common.Interfaces;

public interface ILeaveDistributionService
{
    Task<Response<Guid>> CreateLeaveDistribution(Guid leaveTypeUid);
}
