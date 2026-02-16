using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHomeBFF;

public class EventEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public required string SensorId { get; set; }

    public int SensorType { get; set; }

    public int EventType { get; set; }

    public required string EventValue { get; set; }

    public DateTime? EvaluateAt { get; set; }
}