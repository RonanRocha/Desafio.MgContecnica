using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Application.Dto
{
    public record CreateCategoriaDto(string Nome, TipoCategoria Tipo, StatusCategoria Status);
    public record CategoriaDto(int Id, string Nome, TipoCategoria Tipo, StatusCategoria Status, DateTime DataCriacao, DateTime DataUltimaAtualizacao, List<TransacaoDto> Transacoes);
}
