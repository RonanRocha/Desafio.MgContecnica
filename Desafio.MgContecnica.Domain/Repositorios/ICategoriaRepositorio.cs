using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Domain.Repositorios
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> RecuperarTodasCategoriasAsync();
        Task<Categoria> RecuperarCategoriaPorIdAsync(int id);
        Task<Categoria> CriarCategoriaAsync(Categoria categoria);
        Task<Categoria> AtualizarCategoriaAsync(Categoria categoria);
        Task<Categoria> RemoverCategoriaAsync(Categoria categoria);
    }
}
