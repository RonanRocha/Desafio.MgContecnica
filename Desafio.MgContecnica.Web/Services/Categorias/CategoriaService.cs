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



        public async Task<RespostaPadraoPaginadaModel<List<CategoriaModel>>> ObterCategoriasAsync(FiltroCategoriaModel? filtro = null)
        {
            try
            {
                var url = UrlBuilderHelper.MontarUrlComQuery("https://localhost:44372/api/Categorias", filtro);

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();

                var resultado = await JsonSerializer.DeserializeAsync<RespostaPadraoPaginadaModel<List<CategoriaModel>>>(
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

        public async Task<RespostaPadraoPaginadaModel<CategoriaModel>> CriarCategoriaAsync(CriarCategoriaModel model)
        {

            var url = $"https://localhost:44372/api/Categorias/";

            var response = await _httpClient.PostAsJsonAsync(url, model);

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadFromJsonAsync<RespostaPadraoPaginadaModel<CategoriaModel>>();
                return resultado!;
            }

            return new RespostaPadraoPaginadaModel<CategoriaModel>
            {
                Sucesso = false,
                Mensagem = "Erro ao cadastrar categoria."
            };
        }



    }
}
