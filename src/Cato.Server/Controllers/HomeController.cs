using Cato.JwtService;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Cato.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IJwtService _jwtService;

        public HomeController(
            IHttpClientFactory httpClientFactory,
            IJwtService jwtService)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new System.Uri("https://localhost:5004/");
            _jwtService = jwtService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var token = _jwtService.Token("not valid");
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", token);
            var t = await _httpClient.GetAsync("api/v1/catalog/list");
            var r = await t.Content.ReadAsStringAsync();
            return View("Privacy", r);
        }
    }
}
