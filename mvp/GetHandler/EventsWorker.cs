namespace GetHandler;

/// <summary>
/// Проверяет неотправленные сообщения и переправляет их в хэндлер
/// </summary>
public class EventsWorker(IServiceScopeFactory _scopeFactory) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateAsyncScope();
            var context = scope.ServiceProvider.GetRequiredService<EventsContext>();
            var handler = scope.ServiceProvider.GetRequiredService<EventHandler>();

            var unprocessedMessages = context.Events.Where(x => x.ProcessAt == null).ToArray();

            Parallel.ForEach(unprocessedMessages, async entity =>
                await handler.ProcessMessage(Map(entity), stoppingToken));

            await Task.Delay(1000, stoppingToken);
        }
    }

    private NewEventDto Map(EventEntity entity) =>
        new NewEventDto
        {
            Id = entity.Id,
            EventType = entity.EventType,
            EventValue = entity.EventValue,
            HouseId = entity.HouseId,
            SensorId = entity.SensorId,
            SensorType = entity.SensorType
        };
}