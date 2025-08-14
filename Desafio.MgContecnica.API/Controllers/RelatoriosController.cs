using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.MgContecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> RecuperarResumo()
        {
            return Ok();
        }

        [HttpGet("por-categoria")]
        public async Task<IActionResult> RecuperarPorCategoria()
        {
            return Ok();
        }
    }
}
