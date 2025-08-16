using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Domain.QueryFilters;

namespace Desafio.MgContecnica.Application.Interfaces
{
    public interface ITransacaoService
    {
        Task<List<TransacaoDto>> RecuperarTransacoesAsync(FiltroTransacao filtro);
        Task<TransacaoDto> RecuperarTransacaoPorIdAsync(int id);
        Task<TransacaoDto> CriarTransacaoAsync(CriarTransacaoDto transacaoDto);
        Task AtualizarTransacaoAsync(CriarTransacaoDto transacaoDto);
        Task RemoverTransacaoAsync(int id);
    }
}
