using Desafio.MgContecnica.Web.Models;
using Desafio.MgContecnica.Web.Models.Categorias;
using Desafio.MgContecnica.Web.Models.Transacoes;
using Desafio.MgContecnica.Web.Services.Categorias;
using Desafio.MgContecnica.Web.Services.Transacoes;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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

            try
            {
                filtro.ValidarPaginacao();

                var transacoes = await _transacaoService.ObterTransacoesAsync(filtro);

                var viewModel = new TransacaoViewModel
                {
                    Transacoes = transacoes,
                    CriarTransacaoModel = new CriarTransacaoModel(),
                    Filtro = filtro ?? new FiltroTransacaoModel()
                };

                return View(viewModel);



            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor");
            }

        }

        [HttpGet]
        public async Task<IActionResult> BuscarCategorias(string busca)
        {

            var categorias = await _categoriaService.ObterCategoriasAsync(new FiltroCategoriaModel { Busca = busca });

            if(categorias.Sucesso)
            {
                return Json(new { results = categorias.Dados.Dados });
            }

            return Json(new { results = new List<CategoriaModel>() });

        }


        public async Task<IActionResult> CriarTransacao(CriarTransacaoModel criarTrasansaoModel)
        {
            if (!ModelState.IsValid)
            {
                var transacoes = await _transacaoService.ObterTransacoesAsync();

                var viewModel = new TransacaoViewModel
                {
                    Transacoes = transacoes,
                    CriarTransacaoModel = criarTrasansaoModel
                };

                TempData["Erro"] = "Preencha os campos corretamente.";

                ViewBag.MostrarModal = true;

                return View(nameof(Index), viewModel);
            }

            var resultado = await _transacaoService.CriarTransacaoAsync(criarTrasansaoModel);

            if (resultado.Sucesso)
                TempData["Sucesso"] = "Transação cadastrada com sucesso!";
            else
                TempData["Erro"] = "Erro ao cadastrar transação.";

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> DeletarTransacao(int id)
        {
            
            var transacao = await _transacaoService.RemoverTransacaoAsync(id);

            if(transacao.Sucesso)
            {
                TempData["Sucesso"] = "Transação removida com sucesso!";
            }else
            {
                TempData["Erro"] = "Não foi possível remover transação";
            }

          
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var transacao = await _transacaoService.RecuperarTransacaoPorId(id);

            if (transacao.Sucesso)
            {
                return  PartialView("_FormTransacao", new CriarTransacaoModel
                {
                    Id = transacao.Dados.Id,
                    CategoriaId = transacao.Dados.CategoriaId,
                    Data = DateOnly.FromDateTime(transacao.Dados.Data),
                    Descricao = transacao.Dados.Descricao,
                    Observacoes = transacao.Dados.Observacoes,
                    Valor = transacao.Dados.Valor,
                });
            }

            return BadRequest("Não foi possível abrir página");
    
        }


    }
}
