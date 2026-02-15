using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using RabbitMQ.Client;

namespace GetHandler;

public class EventHandler(EventsContext _context, ConnectionFactory _connFactory) : IEventHandler
{
    public async Task ProcessMessage(NewEventDto dto, CancellationToken token)
    {
        using var tran = await _context.Database.BeginTransactionAsync(token);
        EventEntity entity = Map(dto);

        if (dto.Id is null)
            _context.Events.Attach(entity);
        else
        {
            _context.Events.Add(entity);
            await _context.SaveChangesAsync(token);
        }

        using var conn = await _connFactory.CreateConnectionAsync(token);
        using var channel = await conn.CreateChannelAsync(cancellationToken: token);

        try
        {
            await channel.BasicPublishAsync(body: JsonSerializer.SerializeToUtf8Bytes(dto), routingKey: "inboxEvents", exchange: "");
            entity.ProcessAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(token);
        }
        finally
        {
            await tran.CommitAsync(token);
        }
    }

    private static EventEntity Map(NewEventDto dto) =>
        new EventEntity
        {
            EventType = dto.EventType,
            EventValue = dto.EventValue,
            HouseId = dto.HouseId,
            SensorId = dto.SensorId,
            SensorType = dto.SensorType
        };
}

[JsonSerializable(typeof(NewEventDto))]
[JsonSourceGenerationOptions(WriteIndented = true)]
internal partial class EventsJsonContext : JsonSerializerContext
{ }