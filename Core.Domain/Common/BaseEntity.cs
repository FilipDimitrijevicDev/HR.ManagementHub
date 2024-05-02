using System.Text.Json.Serialization;

namespace Core.Domain.Common;

public abstract class BaseEntity
{
    //[OpenApiExclude]
    [JsonIgnore]
    public int Id { get; set; }
    public Guid Uid { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
