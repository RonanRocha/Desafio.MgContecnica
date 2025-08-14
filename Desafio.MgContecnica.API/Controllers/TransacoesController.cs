using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.MgContecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> RecuperarTodas()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarPorId(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CriarTransacao()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarTransacao(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverTransacao(int id)
        {
            return Ok();
        }
    }
}
