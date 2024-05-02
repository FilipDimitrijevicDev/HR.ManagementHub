using Core.Application.Common.Interfaces;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(DatabaseContext.DatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsLeaveTypeUnique(string name)
    {
        return await _dbContext.LeaveTypes.AnyAsync(t => t.Name == name);
    }
}
