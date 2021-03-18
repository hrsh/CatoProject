using Cato.JwtService;
using Microsoft.AspNetCore.Mvc;

namespace Cato.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public HomeController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet("connect/token")]
        public IActionResult Index()
        {
            var token = _jwtService.Token();
            return Ok(token);
        }
    }
}
