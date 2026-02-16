namespace GetHandler;

public class NewEventDto
{
    public long? Id { get; set; }

    public required string HouseId { get; set; }

    public required string SensorId { get; set; }

    public int SensorType { get; set; }

    public int EventType { get; set; }

    public required string EventValue { get; set; }
}