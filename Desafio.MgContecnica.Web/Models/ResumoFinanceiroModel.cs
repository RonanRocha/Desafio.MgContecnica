using Desafio.MgContecnica.Web.Models.Transacoes;

namespace Desafio.MgContecnica.Web.Models
{
    public class ResumoFinanceiroModel
    {

        public decimal SaldoTotal { get; set; }
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }
        public PaginacaoResponseModel<List<TransacaoModel>> Despesas { get; set; }
        public PaginacaoResponseModel<List<TransacaoModel>> Receitas { get; set; }

    }
}
