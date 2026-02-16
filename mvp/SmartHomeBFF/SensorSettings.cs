namespace SmartHomeBFF;

public class SensorSettings
{
    public required long SensorId { get; set; }

    public required int SensorType { get; set; }

    public string? SettingsObject { get; set; }
}