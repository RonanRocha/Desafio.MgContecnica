using Desafio.MgContecnica.API.Response;
using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Application.Interfaces;
using Desafio.MgContecnica.Application.Response;
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
        public async Task<IActionResult> RecuperarTodas([FromQuery] FiltroTransacaoDto filtro)
        {
            try
            {
                var transacoes = await _transacaoService.RecuperarTransacoesAsync(filtro);

                return Ok(RespostaPadraoApi<PaginacaoResponse<List<TransacaoDto>>>.Ok(transacoes));

            }
            catch (Exception ex)
            {
                return StatusCode(500, RespostaPadraoApi<object>.Falha("Erro interno no servidor"));
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarPorId(int id)
        {
            try
            {
                var transacao = await _transacaoService.RecuperarTransacaoPorIdAsync(id);
                if (transacao == null) return NotFound(RespostaPadraoApi<TransacaoDto?>.Falha("Nenhuma transação encontrada"));

                return Ok(RespostaPadraoApi<TransacaoDto>.Ok(transacao));
            }
            catch (Exception ex)
            {
                return StatusCode(500, RespostaPadraoApi<object>.Falha("Erro interno no servidor"));
            }

        }

        [HttpPost]
        public async Task<IActionResult> CriarTransacao([FromBody] CriarTransacaoDto transacaoDto )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var erros = ModelState.Values
                                   .SelectMany(v => v.Errors)
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
        public async Task<IActionResult> AtualizarTransacao(int id, [FromBody] AtualizarTransacaoDto transacaoDto)
        {
            try
            {

                var transacao = await _transacaoService.RecuperarTransacaoComCategoriaPorIdAsync(id);

                if (transacao == null) return NotFound(RespostaPadraoApi<object>.Falha("Transação não encontrada"));

                await _transacaoService.AtualizarTransacaoAsync(transacao,transacaoDto);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, RespostaPadraoApi<object>.Falha("Erro interno no servidor"));
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverTransacao(int id)
        {
            try
            {               
                var transacao = await _transacaoService.RemoverTransacaoAsync(id);

                if(transacao == null)   return NotFound(RespostaPadraoApi<TransacaoDto>.Falha("Transacao não encontrada"));

                return Ok(RespostaPadraoApi<TransacaoDto>.Ok(transacao));
            }
            catch(Exception ex)
            {
                return StatusCode(500, RespostaPadraoApi<object>.Falha("Erro interno no servidor"));
            }
           
        }
    }
}
