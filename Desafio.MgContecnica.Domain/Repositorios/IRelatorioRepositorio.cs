using Desafio.MgContecnica.Domain.Entities;
using Desafio.MgContecnica.Domain.QueryFilters;

namespace Desafio.MgContecnica.Domain.Repositorios
{
    public interface IRelatorioRepositorio
    {
        Task<ResumoRelatorio> RecuperarResumoAsync(FiltroRelatorio filtroRelatorio);
    }
}
