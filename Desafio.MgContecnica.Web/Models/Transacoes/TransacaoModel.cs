using Desafio.MgContecnica.Web.Models.Categorias;

namespace Desafio.MgContecnica.Web.Models.Transacoes
{
    public class TransacaoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public CategoriaModel Categoria { get; set; }
    }
}
