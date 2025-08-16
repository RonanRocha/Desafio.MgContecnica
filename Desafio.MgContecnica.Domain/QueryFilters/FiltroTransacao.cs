using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Domain.QueryFilters
{
    public class FiltroTransacao : FiltroPaginacao
    {
        public TipoCategoria? Tipo { get; set; }
        public int? CategoriaId { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
    }
}
