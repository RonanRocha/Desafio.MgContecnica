using Desafio.MgContecnica.Web.Models.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.MgContecnica.Web.Models
{
    public class FiltroTransacaoModel : FiltroPaginacaoModel
    {
        [BindProperty]
        public int? CategoriaId { get; set; }

        [BindProperty]
        public DateOnly? DataInicial { get; set; }

        [BindProperty]
        public DateOnly? DataFinal { get; set; }

        [BindProperty]
        public TipoCategoriaModel? Tipo { get; set; }
    }
}

