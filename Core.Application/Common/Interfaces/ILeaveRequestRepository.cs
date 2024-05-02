using Core.Domain;

namespace Core.Application.Common.Interfaces;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestByUid(Guid uid);
    Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
    Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(Guid userUid);
}
