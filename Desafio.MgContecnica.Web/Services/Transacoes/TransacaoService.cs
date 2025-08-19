using Desafio.MgContecnica.Web.Models.Categorias;
using Desafio.MgContecnica.Web.Models;
using System.Net.Http;
using System.Text.Json;
using Desafio.MgContecnica.Web.Models.Transacoes;
using Desafio.MgContecnica.Web.Helpers;

namespace Desafio.MgContecnica.Web.Services.Transacoes
{
    public class TransacaoService
    {


        private readonly HttpClient _httpClient;
        private readonly ILogger<TransacaoService> _logger;

        public TransacaoService(HttpClient httpClient, ILogger<TransacaoService> logger)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<RespostaPadraoModel<List<TransacaoModel>>> ObterTransacoesAsync(FiltroTransacaoModel filtro)
        {
            try
            {

                var url = UrlBuilderHelper.MontarUrlComQuery("https://localhost:44372/api/Transacoes", filtro);

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();

                var resultado = await JsonSerializer.DeserializeAsync<RespostaPadraoModel<List<TransacaoModel>>>(
                    stream,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return resultado;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar categorias");
                throw;
            }
        }

        public async Task<RespostaPadraoModel<TransacaoModel>> CriarTransacaoAsync(CriarTransacaoModel model)
        {

            var url = $"https://localhost:44372/api/Transacoes/";

            var response = await _httpClient.PostAsJsonAsync(url, model);

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadFromJsonAsync<RespostaPadraoModel<TransacaoModel>>();
                return resultado!;
            }

            return new RespostaPadraoModel<TransacaoModel>
            {
                Sucesso = false,
                Mensagem = "Erro ao cadastrar categoria."
            };
        }
    }
}
