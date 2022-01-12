using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/WeatherForecast")]    
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route(nameof(Get))]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route(nameof(Test))]
        public IEnumerable<string> Test()
        {
            //return new List<string>() { "TEs" };
            throw new InvalidOperationException("Das war ei Test");
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.OK)]
        public IActionResult Delete(string name)
        {
            try
            {
                throw new InvalidOperationException("Das war ei Test");
                return Ok(new List<string>());
            }
            catch (Exception ex)
            {
                //J630
                return BadRequest(ex.Message);
            }
        }
    }
}