using Cato.ProtectedApi.Moq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cato.ProtectedApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet("list")]
        [Authorize]
        public IActionResult List() => Ok(CatalogStore.List);

        [HttpGet("find/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Find(int id) => Ok(CatalogStore.Find(id));

        [HttpGet("token")]
        public async Task<IActionResult> GetToken()
        {
            var t = await HttpContext.GetTokenAsync("Bearer", "access_token");
            return Ok(t);
        }
    }
}
