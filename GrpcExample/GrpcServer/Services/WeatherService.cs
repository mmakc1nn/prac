using Microsoft.AspNetCore.Mvc;
using Grpc.Core;
using WeatherServer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcServer.Services;


[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    private static readonly Random _random = new Random();

    [HttpGet("current")]
    public ActionResult<WeatherResponse> GetCurrentWeather([FromQuery] string city)
    {
        var response = new WeatherResponse
        {
            City = city,
            Temperature = _random.Next(10, 30),
            Description = "Солнечно",
            Timestamp = DateTime.UtcNow.ToString("O")
        };
        return Ok(response);
    }

    [HttpGet("multiple")]
    public ActionResult<IEnumerable<WeatherResponse>> GetCurrentWeathers([FromQuery] string city)
    {
        var responses = new List<WeatherResponse>();
        for (int i = 0; i < 10000; i++)
        {
            responses.Add(new WeatherResponse
            {
                City = city,
                Temperature = _random.Next(10, 30),
                Description = "Солнечно",
                Timestamp = DateTime.UtcNow.ToString("O")
            });
        }
        return Ok(responses);
    }
}

public class WeatherServiceImpl : WeatherService.WeatherServiceBase
{
    private readonly Random _random = new Random();

    public override Task<WeatherResponse> GetCurrentWeather(
        WeatherRequest request, ServerCallContext context)
    {
        return Task.FromResult(new WeatherResponse
        {
            City = request.City,
            Temperature = _random.Next(10, 30),
            Description = "Солнечно",
            Timestamp = DateTime.UtcNow.ToString("O")
        });
    }
    public override Task<RepWeatherResponse> GetCurrentWeathers(WeatherRequest request, ServerCallContext context)
    {
        List<WeatherResponse> wr = new List<WeatherResponse>();
        for (int i = 0; i < 10000; i++)
        {
            WeatherResponse response = new WeatherResponse()
            {
                City = request.City,
                Temperature = _random.Next(10, 30),
                Description = "Солнечно",
                Timestamp = DateTime.UtcNow.ToString("O")
            };
            wr.Add(response);
        }
        return Task.FromResult(new RepWeatherResponse 
        { 
            WeatherResponses = { wr } 
        });
    }

    public override async Task MonitorWeather(
        WeatherRequest request,
        IServerStreamWriter<WeatherResponse> responseStream,
        ServerCallContext context)
    {
        while (!context.CancellationToken.IsCancellationRequested)
        {
            var weather = new WeatherResponse
            {
                City = request.City,
                Temperature = _random.Next(10, 30),
                Description = "Солнечно",
                Timestamp = DateTime.UtcNow.ToString("O")
            };

            await responseStream.WriteAsync(weather);
        }
    }

   


}