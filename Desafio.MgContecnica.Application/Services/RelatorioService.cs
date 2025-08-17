using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Application.Interfaces;
using Desafio.MgContecnica.Application.Mappings;
using Desafio.MgContecnica.Domain.Repositorios;

namespace Desafio.MgContecnica.Application.Services
{
    public class RelatorioService : IRelatorioService
    {

        private readonly IRelatorioRepositorio _relatorioRepositorio;

        public RelatorioService(IRelatorioRepositorio relatorioRepositorio)
        {
            _relatorioRepositorio = relatorioRepositorio;   
        }

        public async Task<ResumoRelatorioDto> ObterResumoAsync(FiltroRelatorioDto filtroDto)
        {
            var resumoRelatorio = await _relatorioRepositorio.RecuperarResumoAsync(filtroDto.ToEntity());
            return resumoRelatorio.ToDto(filtroDto);
        }
    }
}
