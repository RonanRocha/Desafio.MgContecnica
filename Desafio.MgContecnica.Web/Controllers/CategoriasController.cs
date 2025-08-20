using Desafio.MgContecnica.Web.Models;
using Desafio.MgContecnica.Web.Models.Categorias;
using Desafio.MgContecnica.Web.Services.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.MgContecnica.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly CategoriaService _categoriaService;

        public CategoriasController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }


        public async Task<IActionResult> Index(FiltroPaginacaoModel filtroPaginacao)
        {
            filtroPaginacao.ValidarPaginacao();

            var categorias = await _categoriaService.ObterCategoriasAsync(filtroPaginacao);

            var viewModel = new CategoriaViewModel
            {
                Categorias = categorias,
                CriarCategoriaModel = new CriarCategoriaModel()
            };


            return View(viewModel);
        }


        public async Task<IActionResult> CriarCategoria(CriarCategoriaModel categoriaModel)
        {
            if (!ModelState.IsValid)
            {
                var categorias = await _categoriaService.ObterCategoriasAsync();

                var viewModel = new CategoriaViewModel
                {
                    Categorias = categorias,
                    CriarCategoriaModel = categoriaModel
                };
           
                TempData["Erro"] = "Preencha os campos corretamente.";

                ViewBag.MostrarModal = true;

                return View(nameof(Index), viewModel);
            }

            var resultado = await _categoriaService.CriarCategoriaAsync(categoriaModel);

            if (resultado.Sucesso)
                TempData["Sucesso"] = "Categoria cadastrada com sucesso!";
            else
                TempData["Erro"] = "Erro ao cadastrar categoria.";

            return RedirectToAction(nameof(Index));
        }

    }
}
