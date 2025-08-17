using Desafio.MgContecnica.Application.Response;
using Desafio.MgContecnica.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace Desafio.MgContecnica.Application.Dto
{
    public record ResumoRelatorioDto(
        decimal SaldoTotal,
        decimal TotalReceitas,
        decimal TotalDespesas,
        PaginacaoResponse<List<TransacaoDto>> Despesas,
        PaginacaoResponse<List<TransacaoDto>> Receitas
    );
}
