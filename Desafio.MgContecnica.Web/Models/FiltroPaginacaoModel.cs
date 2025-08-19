namespace Desafio.MgContecnica.Web.Models
{
    public class FiltroPaginacaoModel
    {
        public int? NumeroPagina { get; set; } = 1;
        public int? TamanhoPagina { get; set; } = 25;


        public void ValidarPaginacao()
        {
            NumeroPagina = NumeroPagina < 1 ? 1 : NumeroPagina;
            TamanhoPagina = TamanhoPagina > 100 ? 100 : TamanhoPagina;
        }
    }
}
