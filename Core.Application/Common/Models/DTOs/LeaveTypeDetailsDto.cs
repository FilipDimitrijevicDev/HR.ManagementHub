namespace Core.Application.Common.Models.DTOs;

public class LeaveTypeDetailsDto
{
    public Guid Uid { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
