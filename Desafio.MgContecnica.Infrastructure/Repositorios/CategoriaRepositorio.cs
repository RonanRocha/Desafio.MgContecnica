using Desafio.MgContecnica.Domain.Entities;
using Desafio.MgContecnica.Domain.Repositorios;
using Desafio.MgContecnica.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.MgContecnica.Infrastructure.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {

        private readonly AppDbContext _appDbContext;

        public CategoriaRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Categoria> AtualizarCategoriaAsync(Categoria categoria)
        {
            _appDbContext.Categorias.Update(categoria);
            await _appDbContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> CriarCategoriaAsync(Categoria categoria)
        {
           await  _appDbContext.Categorias.AddAsync(categoria);
           await _appDbContext.SaveChangesAsync();
           return categoria;    
        }

        public async Task<Categoria> RecuperarCategoriaPorIdAsync(int id)
        {
            return await _appDbContext.Categorias.FindAsync(id);
        }

        public async Task<List<Categoria>> RecuperarTodasCategoriasAsync()
        {
            return await _appDbContext.Categorias.ToListAsync();
        }

        public async  Task<Categoria> RemoverCategoriaAsync(Categoria categoria)
        {
            _appDbContext.Categorias.Remove(categoria);
            await _appDbContext.SaveChangesAsync();
            return categoria;
        }
    }
}
