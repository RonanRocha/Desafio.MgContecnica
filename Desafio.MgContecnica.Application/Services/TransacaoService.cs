using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Application.Interfaces;
using Desafio.MgContecnica.Application.Mappings;
using Desafio.MgContecnica.Domain.QueryFilters;
using Desafio.MgContecnica.Domain.Repositorios;

namespace Desafio.MgContecnica.Application.Services
{
    public class TransacaoService : ITransacaoService
    {

        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public TransacaoService(ITransacaoRepositorio transacaoRepositorio)
        {
            _transacaoRepositorio = transacaoRepositorio;
        }

        public async Task AtualizarTransacaoAsync(CriarTransacaoDto transacaoDto)
        {

            throw new NotImplementedException();
        }

        public async Task<TransacaoDto> CriarTransacaoAsync(CriarTransacaoDto transacaoDto)
        {
            var transacao = transacaoDto.ToEntity();
            await _transacaoRepositorio.CriarTransacaoAsync(transacao);
            return transacao.ToDto();
   
        }

        public Task<TransacaoDto> RecuperarTransacaoPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransacaoDto>> RecuperarTransacoesAsync(FiltroTransacao filtro)
        {
            throw new NotImplementedException();
        }

        public Task RemoverTransacaoAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
