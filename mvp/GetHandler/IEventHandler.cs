namespace GetHandler;

public interface IEventHandler
{
    Task ProcessMessage(NewEventDto dto, CancellationToken token);
}