namespace Desafio.MgContecnica.Domain.QueryFilters
{
    public class FiltroRelatorio 
    {
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public int? NumeroPaginaDespesa { get; set; } = 1;
        public int? TotalPaginaDespesa { get; set; } = 100;
        public int? NumeroPaginaReceita { get; set; } = 1;
        public int? TotalPaginaReceita { get; set; } = 100;
    }
}
