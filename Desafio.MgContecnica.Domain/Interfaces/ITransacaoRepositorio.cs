using Desafio.MgContecnica.Domain.Entities;
using Desafio.MgContecnica.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.MgContecnica.Domain.Interfaces
{
    public interface ITransacaoRepositorio
    {
        Task<IEnumerable<Transacao>> RecuperarTodasTransacoesAsync(TransacoesFiltroQuery filtro);
        Task<Transacao> RecuperarTransacaoPorIdAsync(int id);
        Task<Transacao> CriarTransacaoAsync(Transacao transacao);
        Task<Transacao> AtualizarTransacaoAsync(Transacao transacao);
        Task<Transacao> RemoverTransacaoAsync(Transacao transacao);
    }
}
