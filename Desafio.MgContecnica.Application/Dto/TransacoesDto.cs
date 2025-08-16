using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Application.Dto
{
    public record TransacaoDto(int Id, string Descricao, decimal Valor, DateTime Data, int CategoriaId, string Observacoes, DateTime DataCriacao, DateTime DataUltimaAtualizacao);
}
