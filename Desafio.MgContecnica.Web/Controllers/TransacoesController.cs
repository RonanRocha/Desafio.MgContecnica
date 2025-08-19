using Desafio.MgContecnica.Web.Models;
using Desafio.MgContecnica.Web.Models.Categorias;
using Desafio.MgContecnica.Web.Models.Transacoes;
using Desafio.MgContecnica.Web.Services.Categorias;
using Desafio.MgContecnica.Web.Services.Transacoes;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.MgContecnica.Web.Controllers
{
    public class TransacoesController : Controller
    {

        private readonly TransacaoService _transacaoService;
        private readonly CategoriaService _categoriaService;

        public TransacoesController(TransacaoService transacaoService, CategoriaService categoriaService)
        {     
            _transacaoService = transacaoService;
            _categoriaService = categoriaService;
        }


        public async Task<IActionResult> Index(FiltroTransacaoModel filtro)
        {
            var transacoes = await  _transacaoService.ObterTransacoesAsync(filtro);
          

            var viewModel = new TransacaoViewModel
            {
                Transacoes = transacoes,
                CriarTransacaoModel = new CriarTransacaoModel(),
                Filtro = filtro ?? new FiltroTransacaoModel()
            };

            return View(viewModel);
        }
    }
}
