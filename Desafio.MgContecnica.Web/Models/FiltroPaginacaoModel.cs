namespace Desafio.MgContecnica.Web.Models
{
    public class FiltroPaginacaoModel
    {
        public int? Pagina { get; set; } = 1;
        public int? TamanhoPagina { get; set; } = 25;


        public void ValidarPaginacao()
        {
            Pagina = Pagina < 1 ? 1 : Pagina;
            TamanhoPagina = TamanhoPagina > 100 ? 100 : TamanhoPagina;
        }
    }
}
