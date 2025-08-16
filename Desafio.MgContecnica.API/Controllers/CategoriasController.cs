using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> RecuperarTodas()
        {
            var categorias = await _categoriaService.RecuperarCategoriasAsync();

            if(!categorias.Any())
            {
                return NotFound();
            }

            return Ok(categorias);
        }


        [HttpPost]
        public async Task<IActionResult> CriarCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {
            var categoria = await _categoriaService.CriarCategoriaAsync(categoriaDto);

            return Ok(categoria);
        }
    }
}
