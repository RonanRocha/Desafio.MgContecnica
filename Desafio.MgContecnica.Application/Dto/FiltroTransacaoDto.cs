using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Application.Dto
{
    public record FiltroTransacaoDto
    {
        public TipoCategoria? Tipo { get; set; }
        public int? CategoriaId { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public int? NumeroPagina { get; set; } = 1;
        public int? TamanhoPagina { get; set; } = 100;
    }
}
