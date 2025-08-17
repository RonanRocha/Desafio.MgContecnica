using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Domain.QueryFilters;

namespace Desafio.MgContecnica.Application.Mappings
{
    public static  class FiltroPaginacaoMappingExtension
    {

        public static FiltroPaginacao ToEntity(this FiltroPaginacaoDto dto) =>
        new FiltroTransacao
        {
            NumeroPagina = dto.NumeroPagina,
            TamanhoPagina = dto.TamanhoPagina,
        };
    }
}
