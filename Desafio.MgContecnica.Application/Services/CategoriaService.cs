using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Application.Interfaces;
using Desafio.MgContecnica.Application.Mappings;
using Desafio.MgContecnica.Application.Response;
using Desafio.MgContecnica.Domain.Repositorios;

namespace Desafio.MgContecnica.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaService(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<CategoriaDto> CriarCategoriaAsync(CriarCategoriaDto categoriaDto)
        {
           var categoria  = await _categoriaRepositorio.CriarCategoriaAsync(categoriaDto.ToEntity());
           return categoria.ToDto();
        }

        public async  Task<CategoriaDto> RecuperarCategoriaPorIdAsync(int id)
        {
           var categoria =  await _categoriaRepositorio.RecuperarCategoriaPorIdAsync(id);
           return categoria.ToDto();    
        }

        public async Task<PaginacaoResponse<List<CategoriaDto>>> RecuperarCategoriasAsync(FiltroCategoriaDto filtroDto)
        {

            var categorias = new List<CategoriaDto>();

            var result = await _categoriaRepositorio.RecuperarTodasCategoriasAsync(filtroDto.ToEntity());

            if (result.Items.Any())
            {
                categorias = result.Items.Select(x => x.ToDto()).ToList();
            }

            var response = new PaginacaoResponse<List<CategoriaDto>>(categorias, result.Total, filtroDto.NumeroPagina.GetValueOrDefault(), filtroDto.TamanhoPagina.GetValueOrDefault());

            return response;
 
        }

        public async Task RemoverCategoriaAsync(int id)
        {
            var categoria = await _categoriaRepositorio.RecuperarCategoriaPorIdAsync(id);
            if (categoria == null) throw new Exception("Categoria não encontrada");
            await _categoriaRepositorio.RemoverCategoriaAsync(categoria);
       
        }

        public async Task AtualizarCategoriaAsync(CategoriaDto categoriaDto)
        {
            await _categoriaRepositorio.AtualizarCategoriaAsync(categoriaDto.ToEntity());
        }
    }
}
