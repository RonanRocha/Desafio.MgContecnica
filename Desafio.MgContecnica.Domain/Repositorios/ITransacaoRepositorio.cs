using Desafio.MgContecnica.Domain.Entities;
using Desafio.MgContecnica.Domain.QueryFilters;

namespace Desafio.MgContecnica.Domain.Repositorios
{
    public interface ITransacaoRepositorio
    {
        Task<List<Transacao>> RecuperarTodasTransacoesAsync(TransacoesFiltroQuery filtro);
        Task<Transacao> RecuperarTransacaoPorIdAsync(int id);
        Task<Transacao> CriarTransacaoAsync(Transacao transacao);
        Task<Transacao> AtualizarTransacaoAsync(Transacao transacao);
        Task<Transacao> RemoverTransacaoAsync(Transacao transacao);
    }
}
