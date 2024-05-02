using Core.Application.Common.Interfaces;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(DatabaseContext.DatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<LeaveRequest> GetLeaveRequestByUid(Guid uid)
    {
        var result = await _dbContext.LeaveRequests
            .Include(x => x.LeaveType)
            .SingleOrDefaultAsync(x => x.Uid == uid);

        return result;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        var result = await _dbContext.LeaveRequests
            .Where(x => !string.IsNullOrEmpty(x.RequestingEmployeeId))
            .Include(x => x.LeaveType)
            .ToListAsync();

        return result;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(Guid uid)
    {
        var result = await _dbContext.LeaveRequests
            .Where(x => x.Uid == uid)
            .Include(x => x.LeaveType)
            .ToListAsync();

        return result;
    }
}
