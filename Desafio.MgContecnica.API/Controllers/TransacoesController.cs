using Desafio.MgContecnica.API.Response;
using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.MgContecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {

        private readonly ITransacaoService _transacaoService;

        public TransacoesController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

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
        public async Task<IActionResult> CriarTransacao([FromBody] CriarTransacaoDto transacaoDto )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var erros = ModelState.Values.SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage)
                                   .ToList();

                    return BadRequest(RespostaPadraoApi<object>.Falha("Erro de validação", erros));
                }

                var transacao = await _transacaoService.CriarTransacaoAsync(transacaoDto);

                return Ok(RespostaPadraoApi<TransacaoDto>.Ok(transacao, "Transação realizada com sucesso"));

            }
            catch(Exception ex)
            {
                return StatusCode(500, RespostaPadraoApi<object>.Falha("Erro interno no servidor"));
            }
          
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
