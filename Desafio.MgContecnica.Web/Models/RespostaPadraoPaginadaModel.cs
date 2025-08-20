namespace Desafio.MgContecnica.Web.Models
{
    public class RespostaPadraoPaginadaModel<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public PaginacaoResponseModel<T>? Dados { get; set; }
        public object? Erros { get; set; }
    }

    public class RespostaPadraoModel<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T? Dados { get; set; }
        public object? Erros { get; set; }

    }

}
