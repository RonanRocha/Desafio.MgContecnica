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
            DataFinal = dto.DataFinal,
            DataInicial = dto.DataInicial,
            NumeroPagina = dto.NumeroPagina,
            TamanhoPagina = dto.TamanhoPagina,
            CategoriaId = dto.CategoriaId,

        };
     
    }
}
