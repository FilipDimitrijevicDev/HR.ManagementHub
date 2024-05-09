namespace Core.Application.Common.Models;

public class LeaveType
{
    public Guid Uid { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
