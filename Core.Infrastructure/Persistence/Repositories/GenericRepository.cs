using Core.Application.Common.Interfaces;
using Core.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly DatabaseContext.DatabaseContext _dbContext;
    public GenericRepository(DatabaseContext.DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<T>> GetAsync()
    {
        return await _dbContext.Set<T>()
            .Where(x => x.DeletedDate == null)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>()
            .Where(x => x.DeletedDate == null)
            .AsNoTracking()
            .SingleAsync(x => x.Id == id);
    }

    public async Task<T> GetByUidAsync(Guid uid)
    {
        return await _dbContext.Set<T>()
            .Where(x => x.DeletedDate == null)
            .AsNoTracking()
            .SingleAsync(x => x.Uid == uid);
    }

    public async Task CreateAsync(T entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Remove(entity);

        await _dbContext.SaveChangesAsync();
    }

}
