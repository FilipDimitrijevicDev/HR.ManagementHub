using System.ComponentModel.DataAnnotations;

namespace HR.ManagementHub.BlazorUI.Models.LeaveTypes;

public class LeaveTypeVM
{
    [Required]
    public Guid Uid { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Number Of Days")]
    public int DefaultDays { get; set; }
}
