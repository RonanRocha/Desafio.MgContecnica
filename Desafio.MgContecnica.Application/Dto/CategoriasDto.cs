using Desafio.MgContecnica.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Desafio.MgContecnica.Application.Dto
{
    public record CriarCategoriaDto(

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [StringLength(255, ErrorMessage = "O Nome deve ter no máximo 100 caracteres")]
        string Nome,

        [Required(ErrorMessage = "O Tipo é obrigatório")]
        [EnumDataType(typeof(TipoCategoria), ErrorMessage = "Tipo de categoria inválido, por favor escolha uma das opções 0 = Despesa 1 = Receita")]
        TipoCategoria Tipo,

        [Required(ErrorMessage = "O Status é obrigatório")]
        [EnumDataType(typeof(StatusCategoria), ErrorMessage = "Status inválido,  por favor escolha uma das opções  0 = Inativo 1 = Ativo")]
        StatusCategoria Status
    );

    public record CategoriaResumoDto(
        int Id,
        string Nome,
        TipoCategoria Tipo,
        StatusCategoria Status
    );

    public record CategoriaDto(int Id, string Nome, TipoCategoria Tipo, StatusCategoria Status, DateTime DataCriacao, DateTime DataUltimaAtualizacao, List<TransacaoDto>? Transacoes);
}
