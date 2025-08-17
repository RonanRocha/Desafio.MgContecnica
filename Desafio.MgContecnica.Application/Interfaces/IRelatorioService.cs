using Desafio.MgContecnica.Application.Dto;

namespace Desafio.MgContecnica.Application.Interfaces
{
    public interface IRelatorioService
    {
        Task<ResumoRelatorioDto> ObterResumoAsync(FiltroRelatorioDto filtroDto);
    }
}
