using Desafio.MgContecnica.Domain.Entities;
using Desafio.MgContecnica.Domain.QueryFilters;
using Desafio.MgContecnica.Domain.Repositorios;
using Desafio.MgContecnica.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.MgContecnica.Infrastructure.Repositorios
{
    public class TransacaoRepositorio : ITransacaoRepositorio
    {

        private readonly AppDbContext _appDbContext;

        public TransacaoRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Transacao> AtualizarTransacaoAsync(Transacao transacao)
        {
            _appDbContext.Transacoes.Update(transacao);
            await _appDbContext.SaveChangesAsync();
            return transacao;
        }

        public async Task<Transacao> CriarTransacaoAsync(Transacao transacao)
        {
            await _appDbContext.Transacoes.AddAsync(transacao);
            await _appDbContext.SaveChangesAsync();
            return transacao;
        }

        public async  Task<(List<Transacao> Items, int Total)> RecuperarTodasTransacoesAsync(FiltroTransacao filtro)
        {
           
            var query = _appDbContext.Transacoes
                                     .Include(t => t.Categoria)
                                     .AsQueryable();

            if (filtro.DataInicial.HasValue)
                query = query.Where(t => t.Data >= filtro.DataInicial.Value);

            if (filtro.DataFinal.HasValue)
                query = query.Where(t => t.Data <= filtro.DataFinal.Value);

            if (filtro.CategoriaId.HasValue)
                query = query.Where(t => t.CategoriaId == filtro.CategoriaId.Value);

            if (filtro.Tipo != null)
                query = query.Where(t => t.Categoria.Tipo == filtro.Tipo);


            var total = await query.CountAsync();

            var items = await query.OrderBy(t => t.Data)
                         .Skip((filtro.NumeroPagina.GetValueOrDefault() - 1) * filtro.TamanhoPagina.GetValueOrDefault())
                         .Take(filtro.TamanhoPagina.GetValueOrDefault())
                         .AsNoTracking().ToListAsync();

            return (items, total);

        }


        public async Task<Transacao> RecuperarTransacaoPorIdAsync(int id)
        {
            return await _appDbContext.Transacoes.Include(x => x.Categoria).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async  Task<Transacao> RemoverTransacaoAsync(Transacao transacao)
        {
        
            _appDbContext.Remove(transacao);

            await _appDbContext.SaveChangesAsync();

            return transacao;
        }
    }
}
