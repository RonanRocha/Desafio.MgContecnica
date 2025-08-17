namespace Desafio.MgContecnica.Domain.QueryFilters
{
    public class FiltroPaginacao
    {
        public int? NumeroPagina { get; set; }
        public int? TamanhoPagina { get; set; }

        public FiltroPaginacao()
        {
            NumeroPagina = 1;
            TamanhoPagina = 100;
        }

        public FiltroPaginacao(int numeroPagina, int tamanhoPagina)
        {
            this.NumeroPagina = numeroPagina < 1 ? 1 : numeroPagina;
            this.TamanhoPagina = tamanhoPagina > 100 ? 100 : tamanhoPagina;
        }
    }
}
