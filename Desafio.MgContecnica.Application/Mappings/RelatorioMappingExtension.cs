using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Application.Response;
using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Application.Mappings
{
    public static  class RelatorioMappingExtension
    {

        public static ResumoRelatorio ToEntity(this ResumoRelatorioDto dto)
        {
            var entity = new ResumoRelatorio
            {
                SaldoTotal = dto.SaldoTotal,
                TotalDespesas = dto.TotalDespesas,
                TotalReceitas = dto.TotalReceitas,
                Receitas = (
                    dto.Receitas.Dados.Select(x => x.ToEntity()).ToList() ?? new List<Transacao>(),
                    dto.Receitas.TotalRegistros
                ),

                Despesas = (
                    dto.Despesas.Dados.Select(x => x.ToEntity()).ToList() ?? new List<Transacao>(),
                    dto.Despesas.TotalRegistros
                ),
     
            };

            return entity;
        }


        public static ResumoRelatorioDto ToDto(this ResumoRelatorio entity, FiltroRelatorioDto filtro)
        {
            var dto = new ResumoRelatorioDto
            (
                entity.SaldoTotal,
                entity.TotalDespesas,
                entity.TotalReceitas,
                new PaginacaoResponse<List<TransacaoDto>>(
                    entity.Despesas.ItemsDespesas.Select(x => x.ToDto()).ToList() ?? new List<TransacaoDto>(),
                    entity.Despesas.TotalDespesas,filtro.NumeroPaginaDespesa.GetValueOrDefault(),filtro.TotalPaginaDespesa.GetValueOrDefault()),

                new PaginacaoResponse<List<TransacaoDto>>(
                    entity.Receitas.ItemsReceitas.Select(x => x.ToDto()).ToList() ?? new List<TransacaoDto>(),
                    entity.Receitas.TotalReceitas, filtro.NumeroPaginaReceita.GetValueOrDefault(), filtro.TotalPaginaReceita.GetValueOrDefault())
            
            );

            return dto;
        }


    }
}
