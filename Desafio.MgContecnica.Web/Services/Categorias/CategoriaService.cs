using Desafio.MgContecnica.Web.Helpers;
using Desafio.MgContecnica.Web.Models;
using Desafio.MgContecnica.Web.Models.Categorias;
using System.Text.Json;

namespace Desafio.MgContecnica.Web.Services.Categorias
{
    public class CategoriaService 
    {

        private readonly HttpClient _httpClient;
        private readonly ILogger<CategoriaService> _logger;

        public CategoriaService(HttpClient httpClient, ILogger<CategoriaService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }



        public async Task<RespostaPadraoModel<List<CategoriaModel>>> ObterCategoriasAsync(FiltroCategoriaModel? filtro = null)
        {
            try
            {
                var url = UrlBuilderHelper.MontarUrlComQuery("https://localhost:44372/api/Categorias", filtro);

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();

                var resultado = await JsonSerializer.DeserializeAsync<RespostaPadraoModel<List<CategoriaModel>>>(
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

        public async Task<RespostaPadraoModel<CategoriaModel>> CriarCategoriaAsync(CriarCategoriaModel model)
        {

            var url = $"https://localhost:44372/api/Categorias/";

            var response = await _httpClient.PostAsJsonAsync(url, model);

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadFromJsonAsync<RespostaPadraoModel<CategoriaModel>>();
                return resultado!;
            }

            return new RespostaPadraoModel<CategoriaModel>
            {
                Sucesso = false,
                Mensagem = "Erro ao cadastrar categoria."
            };
        }



    }
}
