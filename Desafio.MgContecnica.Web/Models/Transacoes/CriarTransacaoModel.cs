using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.MgContecnica.Web.Models.Transacoes
{
    public class CriarTransacaoModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O Descrição é obrigatório")]
        [StringLength(255, ErrorMessage = "O Nome deve ter no máximo 100 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Valor é obrigatório")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A Data é obrigatório")]
        public DateOnly? Data { get; set; }

        [Required(ErrorMessage = "CategoriaId é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O CategoriaId deve ser maior que 0")]
        public int CategoriaId { get; set; }

        public string? Observacoes { get; set; }

    }
}


