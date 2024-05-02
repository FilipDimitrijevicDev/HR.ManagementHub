namespace Core.Application.Common.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> GetByUidAsync(Guid uid);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
