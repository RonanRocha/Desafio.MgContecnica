using System.ComponentModel.DataAnnotations;

namespace Desafio.MgContecnica.Web.Models.Categorias
{
    public class CriarCategoriaModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [StringLength(255, ErrorMessage = "O Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Tipo é obrigatório")]
        [EnumDataType(typeof(TipoCategoriaModel), ErrorMessage = "Tipo de categoria inválido, por favor escolha uma das opções 0 = Despesa 1 = Receita")]
        public TipoCategoriaModel? Tipo { get; set; }

        [Required(ErrorMessage = "O Status é obrigatório")]
        [EnumDataType(typeof(StatusCategoriaModel), ErrorMessage = "Status inválido,  por favor escolha uma das opções  0 = Inativo 1 = Ativo")]
        public StatusCategoriaModel? Status { get; set; }
    }
}
