using Desafio.MgContecnica.Application.Dto;
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
            };

            return entity;
        }


        public static ResumoRelatorioDto ToDto(this ResumoRelatorio entity)
        {
            var dto = new ResumoRelatorioDto
            (
                entity.SaldoTotal,
                entity.TotalDespesas,
                entity.TotalReceitas
            );

            return dto;
        }


    }
}
