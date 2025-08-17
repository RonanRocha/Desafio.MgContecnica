using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Application.Response;
using Desafio.MgContecnica.Domain.QueryFilters;

namespace Desafio.MgContecnica.Application.Interfaces
{
    public interface ITransacaoService
    {
        Task<PaginacaoResponse<List<TransacaoDto>>> RecuperarTransacoesAsync(FiltroTransacaoDto filtroDto);
        Task<TransacaoDto> RecuperarTransacaoPorIdAsync(int id);
        Task<TransacaoDto> RecuperarTransacaoComCategoriaPorIdAsync(int id);
        Task<TransacaoDto> CriarTransacaoAsync(CriarTransacaoDto transacaoDto);
        Task<TransacaoDto> AtualizarTransacaoAsync(TransacaoDto transacaoDto, AtualizarTransacaoDto atualizarTransacaoDto);
        Task<TransacaoDto> RemoverTransacaoAsync(int id);
    }
}
