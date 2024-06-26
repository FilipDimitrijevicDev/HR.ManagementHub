﻿using Core.Domain.Common;

namespace Core.Application.Common.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyCollection<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> GetByUidAsync(Guid uid);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
