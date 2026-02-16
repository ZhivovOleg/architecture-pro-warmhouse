namespace SmartHomeBFF;

public class SensorsHandler(SmartHomeContext _ctx) : ISensorsHandler
{
    public Task AddNewSensor(long sensorId, SensorSettings settings)
    {
        throw new NotImplementedException();
    }

    public Task ProcessEvent(EventDto dto)
    {
        _ctx.Events.Add(new EventEntity
        {
            SensorId = dto.SensorId,
            EventType = dto.EventType,
            EventValue = dto.EventValue,
            EvaluateAt = DateTime.Now
        });
        _ctx.SaveChangesAsync();

        return Task.CompletedTask;
    }

    public Task UpdateSensorData(long sensorId)
    {
        throw new NotImplementedException();
    }
}