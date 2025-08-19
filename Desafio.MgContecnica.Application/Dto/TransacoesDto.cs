using Desafio.MgContecnica.Application.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Desafio.MgContecnica.Application.Dto
{

    public record CriarTransacaoDto(

        [Required(ErrorMessage = "O Descrição é obrigatório")]
        [StringLength(255, ErrorMessage = "O Nome deve ter no máximo 100 caracteres")]
        string Descricao,

        [Required(ErrorMessage = "O Valor é obrigatório")]
        [ValorMaiorQueZero(ErrorMessage ="O Valor deve ser maior que zero")]
        decimal Valor,

        [Required(ErrorMessage = "A Data é obrigatório")]
        [DataMaiorQueDataAtual(ErrorMessage ="A Data não deve ser maior que a data atual")]
        DateOnly Data,

        [Required(ErrorMessage = "CategoriaId é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O CategoriaId deve ser maior que 0")]
        [CategoriaAtivaAttribute(ErrorMessage = "CategoriaId inválido")]
        int CategoriaId,

        string? Observacoes
    );

    public record AtualizarTransacaoDto(

        [Required(ErrorMessage = "O Descrição é obrigatório")]
        [StringLength(255, ErrorMessage = "O Nome deve ter no máximo 100 caracteres")]
        string Descricao,

        [Required(ErrorMessage = "O Valor é obrigatório")]
        [ValorMaiorQueZero(ErrorMessage ="O Valor deve ser maior que zero")]
        decimal Valor,

        [Required(ErrorMessage = "A Data é obrigatório")]
        [DataMaiorQueDataAtual(ErrorMessage ="A Data não deve ser maior que a data atual")]
        DateOnly Data,

        [Required(ErrorMessage = "CategoriaId é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O CategoriaId deve ser maior que 0")]
        [CategoriaAtivaAttribute(ErrorMessage = "CategoriaId inválido")]
        int CategoriaId,

        string? Observacoes
    );


    public record TransacaoDto(
        int Id, 
        string Descricao,
        decimal Valor,
        DateTime Data,
        int CategoriaId,
        string Observacoes,
        DateTime DataCriacao,
        DateTime? DataUltimaAtualizacao,
        CategoriaResumoDto Categoria
    );
}
