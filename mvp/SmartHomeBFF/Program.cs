using Microsoft.EntityFrameworkCore;
using SmartHomeBFF;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SmartHomeContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SmartHome")));

builder.Services.AddSingleton<ICommandHandler, CommandHandler>();
builder.Services.AddSingleton<ISensorsHandler, SensorsHandler>();

var app = builder.Build();

app.MapGet("/command", (CommandDto dto, ICommandHandler handler) => handler.ProcessCommand(dto));

app.MapGet("/event", (EventDto dto, ISensorsHandler handler) => handler.ProcessEvent(dto));

app.Run();
