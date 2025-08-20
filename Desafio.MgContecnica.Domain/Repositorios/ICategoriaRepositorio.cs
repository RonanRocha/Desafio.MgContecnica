using Desafio.MgContecnica.Domain.Entities;
using Desafio.MgContecnica.Domain.QueryFilters;

namespace Desafio.MgContecnica.Domain.Repositorios
{
    public interface ICategoriaRepositorio
    {
        Task<(List<Categoria> Items, int Total)> RecuperarTodasCategoriasAsync(FiltroCategoria filtro);
        Task<Categoria> RecuperarCategoriaPorIdAsync(int id);
        Task<Categoria> CriarCategoriaAsync(Categoria categoria);
        Task<Categoria> AtualizarCategoriaAsync(Categoria categoria);
        Task<Categoria> RemoverCategoriaAsync(Categoria categoria);
    }
}
