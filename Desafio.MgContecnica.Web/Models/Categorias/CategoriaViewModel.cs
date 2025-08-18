using Microsoft.AspNetCore.Mvc;

namespace Desafio.MgContecnica.Web.Models.Categorias
{
    public class CategoriaViewModel
    {
        [BindProperty]
        public CriarCategoriaModel CriarCategoriaModel { get; set; }

        [BindProperty]
        public RespostaPadraoModel<List<CategoriaModel>> Categorias { get; set; }
    }
}
