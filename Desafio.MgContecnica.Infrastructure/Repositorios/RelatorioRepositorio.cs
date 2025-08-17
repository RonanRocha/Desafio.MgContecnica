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
                         .Where(x => x.Categoria.Status == StatusCategoria.Ativo);

            if (filtroRelatorio.DataInicial.HasValue)
                query = query.Where(t => t.Data >= filtroRelatorio.DataInicial.Value);

            if (filtroRelatorio.DataFinal.HasValue)
                query = query.Where(t => t.Data <= filtroRelatorio.DataFinal.Value);


            var totais = await query
                .GroupBy(t => t.Categoria.Tipo)
                .Select(g => new { Tipo = g.Key, Total = g.Sum(x => x.Valor) })
                .ToListAsync();

            decimal totalReceitas = totais.FirstOrDefault(x => x.Tipo == TipoCategoria.Receita)?.Total ?? 0;
            decimal totalDespesas = totais.FirstOrDefault(x => x.Tipo == TipoCategoria.Despesa)?.Total ?? 0;

        
            int totalReceitasCount = await query.Where(t => t.Categoria.Tipo == TipoCategoria.Receita).CountAsync();
            var receitas = await query
                .Where(t => t.Categoria.Tipo == TipoCategoria.Receita)
                .OrderByDescending(t => t.Id)
                .Skip((filtroRelatorio.NumeroPaginaReceita.GetValueOrDefault() - 1) * filtroRelatorio.TotalPaginaReceita.GetValueOrDefault())
                .Take(filtroRelatorio.TotalPaginaReceita.GetValueOrDefault())
                .Select(t => new Transacao
                    {
                        Id = t.Id,
                        Descricao = t.Descricao,
                        Valor = t.Valor,
                        Data = t.Data,
                        Categoria = new Categoria { Id = t.Categoria.Id, Nome = t.Categoria.Nome, Status = t.Categoria.Status, Tipo = t.Categoria.Tipo, DataCriacao = t.Categoria.DataCriacao, DataUltimaAtualizacao = t.Categoria.DataUltimaAtualizacao }
                })
                .ToListAsync();

            int totalDespesasCount = await query.Where(t => t.Categoria.Tipo == TipoCategoria.Despesa).CountAsync();
            var despesas = await query
                .Where(t => t.Categoria.Tipo == TipoCategoria.Despesa)
                .OrderByDescending(t => t.Id)
                .Skip((filtroRelatorio.NumeroPaginaDespesa.GetValueOrDefault() - 1) * filtroRelatorio.TotalPaginaDespesa.GetValueOrDefault())
                .Take(filtroRelatorio.TotalPaginaDespesa.GetValueOrDefault())
                   .Select(t => new Transacao
                   {
                       Id = t.Id,
                       Descricao = t.Descricao,
                       Valor = t.Valor,
                       Data = t.Data,
                       Categoria = new Categoria { Id = t.Categoria.Id, Nome = t.Categoria.Nome, Status = t.Categoria.Status, Tipo = t.Categoria.Tipo, DataCriacao = t.Categoria.DataCriacao, DataUltimaAtualizacao = t.Categoria.DataUltimaAtualizacao }
                   })
                .ToListAsync();
     

            return new ResumoRelatorio
            {
                SaldoTotal = totalReceitas - totalDespesas,
                TotalDespesas = totalDespesas,
                TotalReceitas = totalReceitas,
                Receitas =  (receitas, totalReceitasCount),
                Despesas = (despesas, totalDespesasCount)
            };






            //var query = _appDbContext.Transacoes
            //                  .Where(x => x.Categoria.Status == StatusCategoria.Ativo);

            //if (filtroRelatorio.DataInicial.HasValue)
            //    query = query.Where(t => t.Data >= filtroRelatorio.DataInicial.Value);

            //if (filtroRelatorio.DataFinal.HasValue)
            //    query = query.Where(t => t.Data <= filtroRelatorio.DataFinal.Value);

            //var totais = await query
            //    .GroupBy(t => t.Categoria.Tipo)
            //    .Select(g => new
            //    {
            //        Tipo = g.Key,
            //        Total = g.Sum(x => x.Valor)
            //    })
            //    .ToListAsync();

            //var totalReceitas = totais.FirstOrDefault(x => x.Tipo == TipoCategoria.Receita)?.Total ?? 0;
            //var totalDespesas = totais.FirstOrDefault(x => x.Tipo == TipoCategoria.Despesa)?.Total ?? 0;

            //// 2) Todas as transações em UMA query
            //var transacoes = await query
            //    .Select(t => new Transacao
            //    {
            //        Id = t.Id,
            //        Descricao = t.Descricao,
            //        Valor = t.Valor,
            //        Data = t.Data,
            //        Categoria = new Categoria { Id = t.Categoria.Id, Nome = t.Categoria.Nome, Status = t.Categoria.Status, Tipo = t.Categoria.Tipo, DataCriacao = t.Categoria.DataCriacao, DataUltimaAtualizacao = t.Categoria.DataUltimaAtualizacao}
            //    })
            //    .ToListAsync();

            //var receitas = transacoes.Where(t => t.Categoria.Tipo == TipoCategoria.Receita).ToList();
            //var despesas = transacoes.Where(t => t.Categoria.Tipo == TipoCategoria.Despesa).ToList();

            //return new ResumoRelatorio
            //{
            //    SaldoTotal = totalReceitas - totalDespesas,
            //    TotalDespesas = totalDespesas,
            //    TotalReceitas = totalReceitas,
            //    Receitas = receitas,
            //    Despesas = despesas
            //};
        }
    }
}
