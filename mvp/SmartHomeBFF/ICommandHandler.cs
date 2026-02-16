namespace SmartHomeBFF;

public interface ICommandHandler
{
    Task ProcessCommand(CommandDto dto);
}