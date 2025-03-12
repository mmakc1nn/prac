using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using WeatherClient;

var httpHandler = new HttpClientHandler();
httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

using var channel = GrpcChannel.ForAddress("https://localhost:7276", new GrpcChannelOptions
{
    HttpHandler = httpHandler
});

var grpcClient = new WeatherService.WeatherServiceClient(channel);
var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7276") };

Stopwatch sw;

// gRPC запросы

sw = Stopwatch.StartNew();
var currentWeatherGrpc = await grpcClient.GetCurrentWeathersAsync(
    new WeatherRequest { City = "Москва" });
sw.Stop();
Console.WriteLine($"[gRPC] Время выполнения (одновременно 10000 запросов): {sw.ElapsedMilliseconds}");


sw.Restart();
for (int i = 0; i < 10000; i++)
{
    var currentWeather = await grpcClient.GetCurrentWeatherAsync(new WeatherRequest { City = "Москва" });
}
sw.Stop();
Console.WriteLine($"[gRPC] Время выполнения (последовательно 10000 запросов): {sw.ElapsedMilliseconds}");

// REST API запросы
sw.Restart();
var currentWeatherRest = await httpClient.GetFromJsonAsync<WeatherResponse[]>("api/weather/multiple?city=Москва");
sw.Stop();
Console.WriteLine($"\n[REST API] Время выполнения (одновременно 10000 запросов): {sw.ElapsedMilliseconds}");
sw.Restart();
for (int i = 0; i < 10000; i++)
{
    var currentWeather = await httpClient.GetFromJsonAsync<WeatherResponse>("api/weather/current?city=Москва");
}
sw.Stop();
Console.WriteLine($"[REST API] Время выполнения (последовательно 10000 запросов): {sw.ElapsedMilliseconds}");


//Console.WriteLine("\n[gRPC] Начинаем мониторинг погоды...");
//using var monitoring = grpcClient.MonitorWeather(new WeatherRequest { City = "Москва" });
//try
//{
//        await foreach (var weather in monitoring.ResponseStream.ReadAllAsync())
//        {
//            Console.WriteLine($"Текущая погода: {weather.City}, {weather.Temperature}°C, {weather.Description}");
//        }
//}
//catch (RpcException ex)
//{
//    Console.WriteLine($"Ошибка: {ex.Message}");
//}
