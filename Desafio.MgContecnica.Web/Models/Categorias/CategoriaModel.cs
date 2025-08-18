namespace Desafio.MgContecnica.Web.Models.Categorias
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoCategoriaModel Tipo { get; set; }
        public StatusCategoriaModel Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }


    }
}
