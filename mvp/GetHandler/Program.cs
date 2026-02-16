using GetHandler;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EventsContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Events")));

builder.Services.AddSingleton(sp =>
{
    var conf = sp.GetRequiredService<IConfiguration>();
    return new ConnectionFactory
    {
        HostName = conf["RabbitMQ:Host"] ?? "localhost",
        UserName = conf["RabbitMQ:User"] ?? "user",
        Password = conf["RabbitMQ:pass"] ?? "123"
    };
});

builder.Services.AddSingleton<IEventHandler, GetHandler.EventHandler>();
builder.Services.AddHostedService<EventsWorker>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/new", (NewEventDto dto, IEventHandler handler, CancellationToken token) => handler.ProcessMessage(dto, token));

app.Run();
