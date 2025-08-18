using Desafio.MgContecnica.API.Response;
using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Application.Interfaces;
using Desafio.MgContecnica.Application.Response;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Desafio.MgContecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarTodas([FromQuery] FiltroPaginacaoDto filtroDto)
        {
            try
            {
                filtroDto.ValidarPaginacao();

                var categorias = await _categoriaService.RecuperarCategoriasAsync(filtroDto);

                return Ok(RespostaPadraoApi<PaginacaoResponse<List<CategoriaDto>>>.Ok(categorias));

            }
            catch (Exception ex)
            {
                return StatusCode(500, RespostaPadraoApi<object>.Falha("Erro interno no servidor"));
            }

        }


        [HttpPost]
        public async Task<IActionResult> CriarCategoria([FromBody] CriarCategoriaDto categoriaDto)
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
                  

                var categoria = await _categoriaService.CriarCategoriaAsync(categoriaDto);

                return Ok(RespostaPadraoApi<object>.Ok(categoria, "Categoria registrada com sucesso"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, RespostaPadraoApi<object>.Falha("Erro de validação"));
            }

    
        }
    }
}
