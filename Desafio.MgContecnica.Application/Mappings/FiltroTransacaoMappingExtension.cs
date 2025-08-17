using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Domain.QueryFilters;

namespace Desafio.MgContecnica.Application.Mappings
{
    public static  class FiltroTransacaoMappingExtension
    {

        public static FiltroTransacao ToEntity(this FiltroTransacaoDto dto) =>
        new FiltroTransacao
        {
            Tipo = dto.Tipo,
            DataFinal = dto.DataFinal?.ToDateTime(TimeOnly.MinValue),
            DataInicial = dto.DataInicial?.ToDateTime(TimeOnly.MinValue),
            NumeroPagina = dto.NumeroPagina,
            TamanhoPagina = dto.TamanhoPagina,
            CategoriaId = dto.CategoriaId,

        };
     
    }
}
