using Desafio.MgContecnica.Web.Models.Categorias;

namespace Desafio.MgContecnica.Web.Models
{
    public class FiltroTransacaoModel : FiltroPaginacaoModel
    {
        public int? CategoriaId { get; set; }
        public DateOnly? DataInicial { get; set; }
        public DateOnly? DataFinal { get; set; }
        public TipoCategoriaModel? Tipo { get; set; }
    }
}

