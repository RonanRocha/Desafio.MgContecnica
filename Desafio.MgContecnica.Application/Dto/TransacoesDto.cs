using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Application.Dto
{
    public class TransacoesDto
    {
        public record RecuperarTransacoesDto(int Id, string Descricao, decimal Valor, DateTime Data, int CategoriaId, string Observacoes, DateTime DataCriacao, DateTime DataUltimaAtualizacao, Categoria Categoria);
        public record CriarTransacaoDto(string Descricao, decimal Valor, DateTime Data, int CategoriaId, string Observacoes);
        public record AtualizarTransacaoDto(string Descricao, decimal Valor, DateTime Data, int CategoriaId, string Observacoes);
    }
}
