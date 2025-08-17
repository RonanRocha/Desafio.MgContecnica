using Desafio.MgContecnica.API.Response;
using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.MgContecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {

        private readonly IRelatorioService _relatorioService;

        public RelatoriosController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;   
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarResumo([FromQuery] FiltroRelatorioDto filtroDto)
        {
            try
            {
                var resumoRelatorio = await _relatorioService.ObterResumoAsync(filtroDto);

                return Ok(RespostaPadraoApi<ResumoRelatorioDto>.Ok(resumoRelatorio));

            }
            catch (Exception ex)
            {
                return StatusCode(500, RespostaPadraoApi<object>.Falha("Erro interno no servidor"));
            }
           
        }

        [HttpGet("{categoriaId}")]
        public async Task<IActionResult> RecuperarPorCategoria(int categoriaId)
        {
            return Ok();
        }
    }
}
