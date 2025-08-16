namespace Desafio.MgContecnica.API.Response
{
    public class RespostaPadraoApi<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T? Dados { get; set; }
        public List<string>? Erros { get; set; }

        public static RespostaPadraoApi<T> Ok(T dados, string mensagem = "Operação realizada com sucesso")
            => new RespostaPadraoApi<T> { Sucesso = true, Mensagem = mensagem, Dados = dados };

        public static RespostaPadraoApi<T> Falha(string mensagem, List<string>? erros = null)
            => new RespostaPadraoApi<T> { Sucesso = false, Mensagem = mensagem, Erros = erros };
    }
}
