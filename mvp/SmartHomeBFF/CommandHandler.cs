namespace SmartHomeBFF;

public class CommandHandler(SmartHomeContext _ctx) : ICommandHandler
{
    /// <summary>
    /// Сохраняем настройку/команду в лог и применяем
    /// </summary>
    public Task ProcessCommand(CommandDto dto)
    {
        _ctx.Settings.Add(new SmartHomeSettingsEntity
        {
            SettingName = dto.CommandType.ToString(),
            SettingValue = dto.CommandValue
        });
        _ctx.SaveChanges();
        // дальше обновляем настройку

        return Task.CompletedTask;
    }
}