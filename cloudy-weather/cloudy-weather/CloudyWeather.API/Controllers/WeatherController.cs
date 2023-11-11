using Microsoft.AspNetCore.Mvc;

namespace CloudyWeather.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly bool _isLocal;

        public WeatherController(IConfiguration configuration)
        {
            _isLocal = configuration.GetValue<string>("SYS_ENVIRONMENT") == "LOCAL";
        }

        [HttpGet("")]
        public IActionResult GetCurrentWeather()
        {
            if (_isLocal)
            {
                return Ok("The weather is great.");
            }

            return Ok("The weather is snowy.");
        }
    }
}