using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Domain.QueryFilters;

namespace Desafio.MgContecnica.Application.Mappings
{
    public static  class FiltroCategoriaMappingExtension
    {

        public static FiltroCategoria ToEntity(this FiltroCategoriaDto dto) =>
         new FiltroCategoria
         {
             Busca = dto.Busca,
             NumeroPagina = dto.NumeroPagina,
             TamanhoPagina = dto.TamanhoPagina

         };

    }
}
