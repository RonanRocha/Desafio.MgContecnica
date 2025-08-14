using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Domain.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<IEnumerable<Categoria>> RecuperarTodasCategoriasAsync();
        Task<Categoria> RecuperarCategoriaPorIdAsync(int id);
        Task<Categoria> CriarCategoriaAsync(Categoria categoria);
        Task<Categoria> AtualizarCategoriaAsync(Categoria categoria);
        Task<Categoria> RemoverCategoriaAsync(Categoria categoria);
    }
}
