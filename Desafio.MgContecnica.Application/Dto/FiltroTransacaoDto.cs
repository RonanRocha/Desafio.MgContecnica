using Desafio.MgContecnica.Application.ValidationAttributes;
using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Application.Dto
{
    [DataRangeRequiredAttribute]
    public record FiltroTransacaoDto
    {
        public TipoCategoria? Tipo { get; set; }
        public int? CategoriaId { get; set; }
        public DateOnly? DataInicial { get; set; }
        public DateOnly? DataFinal { get; set; }
        public int? NumeroPagina { get; set; } = 1;
        public int? TamanhoPagina { get; set; } = 100;
    }
}
