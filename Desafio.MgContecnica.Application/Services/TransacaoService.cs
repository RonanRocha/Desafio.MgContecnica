using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Application.Interfaces;
using Desafio.MgContecnica.Application.Mappings;
using Desafio.MgContecnica.Application.Response;
using Desafio.MgContecnica.Domain.Entities;
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

        public async Task<TransacaoDto> AtualizarTransacaoAsync(TransacaoDto transacaoDto, AtualizarTransacaoDto atualizarTransacaoDto)
        {
            var transacao = transacaoDto.ToEntity();

            transacao.Data = atualizarTransacaoDto.Data.ToDateTime(TimeOnly.MinValue);
            transacao.Descricao = atualizarTransacaoDto.Descricao;
            transacao.CategoriaId = atualizarTransacaoDto.CategoriaId;
            transacao.Valor = atualizarTransacaoDto.Valor;
            transacao.DataUltimaAtualizacao = DateTime.UtcNow;
            transacao.Observacoes = atualizarTransacaoDto.Observacoes;

            await _transacaoRepositorio.AtualizarTransacaoAsync(transacao);

            return transacao.ToDto();
       
        }

        public async Task<TransacaoDto> CriarTransacaoAsync(CriarTransacaoDto transacaoDto)
        {
            var transacao = transacaoDto.ToEntity();
            await _transacaoRepositorio.CriarTransacaoAsync(transacao);
            return transacao.ToDto();   
        }

        public async Task<TransacaoDto> RecuperarTransacaoComCategoriaPorIdAsync(int id)
        {
            var transacao = await _transacaoRepositorio.RecuperarTransacaoPorIdAsync(id);
            return transacao?.ToDto();
        }

        public async Task<TransacaoDto> RecuperarTransacaoPorIdAsync(int id)
        {
            var transacao = await _transacaoRepositorio.RecuperarTransacaoPorIdAsync(id);
            return transacao?.ToDto();
        }

        public async Task<PaginacaoResponse<List<TransacaoDto>>> RecuperarTransacoesAsync(FiltroTransacaoDto filtroDto)
        {
            var transacoes = new List<TransacaoDto>();

            var result = await _transacaoRepositorio.RecuperarTodasTransacoesAsync(filtroDto.ToEntity());

            if(result.Items.Any())
            {
                transacoes = result.Items.Select(x => x.ToDto()).ToList();
            }
          
            var response = new PaginacaoResponse<List<TransacaoDto>>(transacoes, result.Total, filtroDto.NumeroPagina.GetValueOrDefault(), filtroDto.TamanhoPagina.GetValueOrDefault());

            return response;    
        }

        public async Task<TransacaoDto> RemoverTransacaoAsync(int id)
        {
             var transacao = await _transacaoRepositorio.RecuperarTransacaoPorIdAsync(id);
             if (transacao == null) return null;

            await _transacaoRepositorio.RemoverTransacaoAsync(transacao);              
             return transacao?.ToDto();             
        }
    }
}
