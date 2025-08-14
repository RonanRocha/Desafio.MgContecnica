using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Application.Dto
{
    public record RecuperarCategoriaDto(int Id, string Nome, TipoCategoria Tipo, StatusCategoria Status, DateTime DataCriacao, DateTime DataUltimaAtualizacao);
    public record CriarCategoriaDto(string Nome, TipoCategoria Tipo, StatusCategoria Status);
    public record AtualizarCategoriasDto(string Nome, TipoCategoria Tipo, StatusCategoria Status);
}
