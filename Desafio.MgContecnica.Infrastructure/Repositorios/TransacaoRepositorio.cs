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

        public async  Task<List<Transacao>> RecuperarTodasTransacoesAsync(FiltroTransacao filtro)
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

            query = query.OrderBy(t => t.Data)
                         .Skip((filtro.NumeroPagina - 1) * filtro.TamanhoPagina)
                         .Take(filtro.TamanhoPagina)
                         .AsNoTracking();

            return await query.ToListAsync();

        }

        public async Task<Transacao> RecuperarTransacaoPorIdAsync(int id)
        {
            return await _appDbContext.Transacoes.FindAsync(id);
        }

        public async  Task<Transacao> RemoverTransacaoAsync(Transacao transacao)
        {
            _appDbContext.Transacoes.Remove(transacao);
            await _appDbContext.SaveChangesAsync();
            return transacao;
        }
    }
}
