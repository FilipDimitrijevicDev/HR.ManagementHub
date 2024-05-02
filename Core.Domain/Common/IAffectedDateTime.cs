namespace Core.Domain.Common;

public interface IAffectedDateTimes
{
    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
