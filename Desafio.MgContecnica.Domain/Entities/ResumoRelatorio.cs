namespace Desafio.MgContecnica.Domain.Entities
{
    public class ResumoRelatorio
    {
        public decimal SaldoTotal { get; set; }
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }

        public (List<Transacao> ItemsReceitas , int TotalReceitas) Receitas { get; set; }
        public (List<Transacao> ItemsDespesas, int TotalDespesas) Despesas { get; set; }

        //public List<Transacao> Receitas { get; set; } = new();
        //public List<Transacao> Despesas { get; set; } = new();
    }
}

