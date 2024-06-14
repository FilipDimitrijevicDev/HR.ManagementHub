using Core.Domain.Common;

namespace Core.Domain;

public class LeaveDistribution : BaseEntity
{
    public int NumberOfDays { get; set; }
    public Guid LeaveTypeUid { get; set; }
    public int LeaveTypeId { get; set; }
    public LeaveType? LeaveType { get; set; }
    public int Period { get; set; }
    public string EmployeeUid { get; set; }
}
