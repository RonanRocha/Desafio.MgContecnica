using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Application.Response;

namespace Desafio.MgContecnica.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<PaginacaoResponse<List<CategoriaDto>>> RecuperarCategoriasAsync(FiltroPaginacaoDto filtroDto);
        Task<CategoriaDto> RecuperarCategoriaPorIdAsync(int id);
        Task<CategoriaDto> CriarCategoriaAsync(CriarCategoriaDto categoriaDto);
        Task AtualizarCategoriaAsync(CategoriaDto categoriaDto);
        Task RemoverCategoriaAsync(int id);
    }
}
