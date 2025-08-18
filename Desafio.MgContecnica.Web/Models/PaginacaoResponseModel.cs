namespace Desafio.MgContecnica.Web.Models
{
    public class PaginacaoResponseModel<T>
    {
        public T Dados { get; set; }
        public int PaginaAtual { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
    }
}
