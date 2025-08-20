using Microsoft.AspNetCore.Mvc;

namespace Desafio.MgContecnica.Web.Models.Categorias
{
    public class CategoriaViewModel
    {
        [BindProperty]
        public CriarCategoriaModel CriarCategoriaModel { get; set; }

        [BindProperty]
        public RespostaPadraoPaginadaModel<List<CategoriaModel>> Categorias { get; set; }
    }
}
