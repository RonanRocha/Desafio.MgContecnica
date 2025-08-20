using Desafio.MgContecnica.Domain.Entities;
using Desafio.MgContecnica.Domain.QueryFilters;
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

        public async Task<(List<Categoria> Items, int Total)> RecuperarTodasCategoriasAsync(FiltroCategoria filtro)
        {

            var query = _appDbContext.Categorias
                                    .AsQueryable();

            if(!string.IsNullOrEmpty(filtro.Busca))
            {
                query = query.Where(c => c.Nome.Contains(filtro.Busca));
            }


            var total = await query.CountAsync();

            var items = await query.OrderByDescending(c => c.Id)
                         .Skip((filtro.NumeroPagina.GetValueOrDefault() - 1) * filtro.TamanhoPagina.GetValueOrDefault())
                         .Take(filtro.TamanhoPagina.GetValueOrDefault())
                         .AsNoTracking().ToListAsync();

            return (items, total);

           
        }

        public async  Task<Categoria> RemoverCategoriaAsync(Categoria categoria)
        {
            _appDbContext.Categorias.Remove(categoria);
            await _appDbContext.SaveChangesAsync();
            return categoria;
        }
    }
}
