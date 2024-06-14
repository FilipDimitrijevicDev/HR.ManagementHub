using Core.Application.Common.Interfaces;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence.Repositories;

public class LeaveDistributionRepository : GenericRepository<LeaveDistribution>, ILeaveDistributionRepository
{
    public LeaveDistributionRepository(DatabaseContext.DatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task AddDistribution(List<LeaveDistribution> leaveDistributions)
    {
        await _dbContext.AddRangeAsync(leaveDistributions);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> DistributionExists(string employeeUid, Guid leaveTypeUid, int period)
    {
        return await _dbContext.LeaveDistributions.AnyAsync(x => x.LeaveTypeUid == leaveTypeUid && x.Period == period && x.EmployeeUid == employeeUid);      
    }

    public async Task<List<LeaveDistribution>> GetLeaveDistributions(Guid userUid)
    {
        var result = await _dbContext.LeaveDistributions
            .Where(x => x.EmployeeUid == userUid.ToString())
            .Include(x => x.LeaveType)
            .ToListAsync();

        return result;
    }

    public async Task<LeaveDistribution> GetLeaveDistributionWithDetails(Guid uid)
    {
        var result = await _dbContext.LeaveDistributions
             .Include(x => x.LeaveType)
             .SingleOrDefaultAsync(x => x.Uid == uid);

        return result;
    }

    public async Task<List<LeaveDistribution>> GetLeaveDistributionWithDetails()
    {
        var result = await _dbContext.LeaveDistributions
            .Include(x => x.LeaveType)
            .ToListAsync();

        return result;
    }

    public async Task<LeaveDistribution> GetUserDistributions(Guid userUid, Guid leaveTypeUid)
    {
        return await _dbContext.LeaveDistributions.SingleOrDefaultAsync(x => x.EmployeeUid == userUid.ToString() && x.Uid == leaveTypeUid);
    }
}