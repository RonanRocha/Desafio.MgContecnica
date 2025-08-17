namespace Desafio.MgContecnica.Application.Response
{
    public class PaginacaoResponse<T>
    {
        public T Dados { get; set; }
        public int PaginaAtual { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }

        public PaginacaoResponse(T dados, int totalRegistros, int paginaAtual, int tamanhoPagina)
        {
            Dados = dados;
            TotalRegistros = totalRegistros;
            PaginaAtual = paginaAtual;
            TamanhoPagina = tamanhoPagina;
            TotalPaginas = (int)Math.Ceiling(totalRegistros / (double)tamanhoPagina);
        }
    }

}
