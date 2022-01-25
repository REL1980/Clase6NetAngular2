//controlador que es de tipo API Controler
using Microsoft.AspNetCore.Mvc;

namespace Clase6NetAngular.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    //básicamente es para loguear información
    private readonly ILogger<WeatherForecastController> _logger;//controlador de pronóstico de tiempo

    
    //costructor que hace una inyección de dependencia
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get(string keyword)
    {
        var list =  Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        var busquedaList = list.Where(x => keyword == null || (keyword != null && x.Summary.Contains(keyword))).ToArray();

        return busquedaList;
    }
}
