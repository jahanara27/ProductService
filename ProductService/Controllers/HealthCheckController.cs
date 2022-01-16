using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [Route("v1/hc")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public HealthCheckController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(configuration["version"]);
        }
    }
}
