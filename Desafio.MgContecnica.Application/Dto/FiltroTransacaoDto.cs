using Desafio.MgContecnica.Application.ValidationAttributes;
using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Application.Dto
{
    [FiltroDataTransacaoAttribute]
    public record FiltroTransacaoDto : FiltroPaginacaoDto
    {
        public TipoCategoria? Tipo { get; set; }
        public int? CategoriaId { get; set; }
        public DateOnly? DataInicial { get; set; }
        public DateOnly? DataFinal { get; set; }

    }
}
