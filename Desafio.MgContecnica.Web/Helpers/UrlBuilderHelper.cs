using System.Reflection;
using System.Web;

namespace Desafio.MgContecnica.Web.Helpers
{

    public static class UrlBuilderHelper
    {
        public static string MontarUrlComQuery<T>(string baseUrl, T filtro)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if(filtro == null) return baseUrl;

            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                var valor = prop.GetValue(filtro);
                if (valor == null) continue;

                // Formatar DateOnly como yyyy-MM-dd
                if (valor is DateOnly date)
                    query[prop.Name] = date.ToString("yyyy-MM-dd");
                else
                    query[prop.Name] = valor.ToString();
            }

            return $"{baseUrl}?{query}";
        }
    }
}

