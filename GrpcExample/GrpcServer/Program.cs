using GrpcServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(7276, listenOptions =>
    {
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core
            .HttpProtocols.Http1AndHttp2;
        listenOptions.UseHttps();
    });
});

builder.Services.AddGrpc();
builder.Services.AddSingleton<WeatherServiceImpl>();
builder.Services.AddControllers();


var app = builder.Build();

app.MapGrpcService<WeatherServiceImpl>();
app.MapControllers();
app.Run();