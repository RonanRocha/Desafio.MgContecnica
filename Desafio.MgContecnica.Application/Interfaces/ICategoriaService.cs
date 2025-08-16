using Desafio.MgContecnica.Application.Dto;

namespace Desafio.MgContecnica.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDto>> RecuperarCategoriasAsync();
        Task<CategoriaDto> RecuperarCategoriaPorIdAsync(int id);
        Task<CategoriaDto> CriarCategoriaAsync(CreateCategoriaDto categoriaDto);
        Task AtualizarCategoriaAsync(CategoriaDto categoriaDto);
        Task RemoverCategoriaAsync(int id);
    }
}
