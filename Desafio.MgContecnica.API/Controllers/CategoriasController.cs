using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.MgContecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> RecuperarTodas()
        {
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> CriarCategoria()
        {
            return Ok();
        }
    }
}
