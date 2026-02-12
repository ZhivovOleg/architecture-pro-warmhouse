using temperatureApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/temperature", (string location) =>
{
    var result = new TemperatureResponse
    {
        Description = "some sensor",
        Location = location,
        SensorId = new Random().Next(100000).ToString(),
        SensorType = "temperature",
        Status = "Ok",
        Timestamp = DateTime.Now,
        Unit = "unit",
        Value = new Random().Next(-50, 50)
    };

    return result;
});

app.MapGet("/temperature/{id}", (string id) =>
{
    var result = new TemperatureResponse
    {
        Description = "some sensor",
        Location = "some location",
        SensorId = id,
        SensorType = "temperature",
        Status = "Ok",
        Timestamp = DateTime.Now,
        Unit = "unit",
        Value = new Random().Next(-50, 50)
    };

    return result;
});


app.Run();
