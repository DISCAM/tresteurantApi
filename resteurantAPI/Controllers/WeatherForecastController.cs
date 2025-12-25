using Microsoft.AspNetCore.Mvc;

namespace resteurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _service;

        public WeatherForecastController(IWeatherForecastService service)
        {
            _service = service;
        }

        /// zmiana tak ¿e sie pozbywamy 
        /// public WeatherForecastController()
        //{
        //    _service = new WeatherForecastService();
        //}


        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _service.Get();
            return result;
        }

        [HttpGet]
        [Route("get2")]
        public IEnumerable<WeatherForecast> Get2()
        {
            var result = _service.Get();
            return result;
           
        }

        [HttpGet("get3/{max}")]
        public IEnumerable<WeatherForecast> Get3([FromQuery]int take, [FromRoute] int max)
        {
            var result = _service.Get();
            return result;

        }

        [HttpPost]
        public ActionResult<string> Hello([FromBody] string name)
        {
            //HttpContext.Response.StatusCode = 401;
            //return StatusCode(401, $"Hello {name}");
            return NotFound($"Hello {name}");

        }


    }
}
