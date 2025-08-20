using Microsoft.AspNetCore.Mvc;

namespace Desafio.MgContecnica.Web.Models.Transacoes
{
    public class TransacaoViewModel
    {

        [BindProperty]
        public  FiltroTransacaoModel Filtro { get; set; }

        [BindProperty]
        public CriarTransacaoModel CriarTransacaoModel { get; set; }

        [BindProperty]
        public RespostaPadraoPaginadaModel<List<TransacaoModel>> Transacoes { get; set; }
    }
}
