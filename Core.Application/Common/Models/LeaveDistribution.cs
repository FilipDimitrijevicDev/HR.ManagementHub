using Core.Application.Common.Models.DTOs;

namespace Core.Application.Common.Models;

public class LeaveDistribution
{
    public Guid Uid { get; set; }
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public required LeaveTypeDto LeaveType { get; set; }
    public int Period { get; set; }
}
