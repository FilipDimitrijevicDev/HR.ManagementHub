using Core.Domain;

namespace Core.Application.Common.Interfaces;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{
    Task<bool> IsLeaveTypeUnique(string name);
}
