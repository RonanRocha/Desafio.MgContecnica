using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Domain.QueryFilters;

namespace Desafio.MgContecnica.Application.Mappings
{
    public static  class FiltroRelatorioMappingExtension
    {

        public static FiltroRelatorio ToEntity(this FiltroRelatorioDto dto) =>
        new FiltroRelatorio
        {
            DataFinal = dto.DataFinal?.ToDateTime(TimeOnly.MinValue),
            DataInicial = dto.DataInicial?.ToDateTime(TimeOnly.MinValue),

        };
    }
}
