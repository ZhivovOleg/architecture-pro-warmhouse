namespace SmartHomeBFF;

public interface ISensorsHandler
{
    Task AddNewSensor(long sensorId, SensorSettings settings);

    Task UpdateSensorData(long sensorId);

    Task ProcessEvent(EventDto dto);
}