using Core.Application.Common.Models.Identity;

namespace Core.Application.Common.Identity;

public interface IUserService
{
    Task<List<Employee>> GetEmployees();
    Task<Employee> GetEmployee(string userId);
    public string UserId { get; }
}
