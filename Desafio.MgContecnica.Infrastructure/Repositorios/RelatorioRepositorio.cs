using Desafio.MgContecnica.Domain.Entities;
using Desafio.MgContecnica.Domain.QueryFilters;
using Desafio.MgContecnica.Domain.Repositorios;
using Desafio.MgContecnica.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.MgContecnica.Infrastructure.Repositorios
{
    public class RelatorioRepositorio : IRelatorioRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public RelatorioRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResumoRelatorio> RecuperarResumoAsync(FiltroRelatorio filtroRelatorio)
        {
            var query = _appDbContext.Transacoes
                            .Where(t => t.Data >= filtroRelatorio.DataInicial && t.Data <= filtroRelatorio.DataFinal);

            var totalReceitas = await query
                .Where(t => t.Categoria.Tipo == TipoCategoria.Receita && t.Categoria.Status == StatusCategoria.Ativo)
                .SumAsync(t => (decimal?)t.Valor) ?? 0;

            var totalDespesas = await query
                .Where(t => t.Categoria.Tipo == TipoCategoria.Despesa && t.Categoria.Status == StatusCategoria.Ativo)
                .SumAsync(t => (decimal?)t.Valor) ?? 0;

            var saldoTotal = totalReceitas - totalDespesas;

            return new ResumoRelatorio
            {
                SaldoTotal = saldoTotal,
                TotalDespesas = totalDespesas,
                TotalReceitas = totalReceitas,
               
            };
        
        }
    }
}
