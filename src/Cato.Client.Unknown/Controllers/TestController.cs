using Cato.JwtService;
using Microsoft.AspNetCore.Mvc;

namespace Cato.Client.Unknown.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public TestController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet("connect/token")]
        public IActionResult Index()
        {
            var token = _jwtService.Token("test");
            return Ok(token);
        }
    }
}
