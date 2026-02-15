using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetHandler;

public class EventEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public required string HouseId { get; set; }

    public required string SensorId { get; set; }

    public int SensorType { get; set; }

    public int EventType { get; set; }

    public required string EventValue { get; set; }

    public DateTime? ProcessAt { get; set; }
}