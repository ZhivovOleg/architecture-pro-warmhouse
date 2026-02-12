using System.Text.Json.Serialization;

namespace temperatureApi;

public class TemperatureResponse
{
    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("sensor_id")]
    public string? SensorId { get; set; }

    [JsonPropertyName("sensor_type")]
    public string? SensorType { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}