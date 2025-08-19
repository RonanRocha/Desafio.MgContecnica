using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Text;

namespace Desafio.MgContecnica.Web.Helpers
{
    public static class PaginationHelper
    {

        public static IHtmlContent Pager(this IHtmlHelper html, int paginaAtual, int totalPaginas, string actionName, object? routeValues = null)
        {
            if (totalPaginas <= 1) return HtmlString.Empty;

            var urlHelperFactory = (IUrlHelperFactory)html.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory))!;
            var urlHelper = urlHelperFactory.GetUrlHelper(html.ViewContext);

            var sb = new StringBuilder();
            sb.Append("<nav aria-label='Navegação de página'><ul class='pagination justify-content-center'>");

            // Botão "Anterior"
            if (paginaAtual > 1)
            {
                sb.AppendFormat(
                    "<li class='page-item'><a class='page-link' href='{0}' aria-label='Anterior'>&laquo;</a></li>",
                    urlHelper.Action(actionName, MergeRouteValues(routeValues, new { NumeroPagina = paginaAtual - 1 })));
            }
            else
            {
                sb.Append("<li class='page-item disabled'><span class='page-link' aria-hidden='true'>&laquo;</span></li>");
            }

            // Páginas
            int maxPagesToShow = 5;
            int startPage = Math.Max(1, paginaAtual - (maxPagesToShow / 2));
            int endPage = Math.Min(totalPaginas, startPage + maxPagesToShow - 1);

            for (int i = startPage; i <= endPage; i++)
            {
                if (i == paginaAtual)
                    sb.AppendFormat("<li class='page-item active' aria-current='page'><span class='page-link'>{0}</span></li>", i);
                else
                    sb.AppendFormat("<li class='page-item'><a class='page-link' href='{0}'>{1}</a></li>",
                        urlHelper.Action(actionName, MergeRouteValues(routeValues, new { NumeroPagina = i })), i);
            }

            // Botão "Próximo"
            if (paginaAtual < totalPaginas)
            {
                sb.AppendFormat(
                    "<li class='page-item'><a class='page-link' href='{0}' aria-label='Próximo'>&raquo;</a></li>",
                    urlHelper.Action(actionName, MergeRouteValues(routeValues, new { NumeroPagina = paginaAtual + 1 })));
            }
            else
            {
                sb.Append("<li class='page-item disabled'><span class='page-link' aria-hidden='true'>&raquo;</span></li>");
            }

            sb.Append("</ul></nav>");
            return new HtmlString(sb.ToString());
        }

        private static object MergeRouteValues(object? original, object newValues)
        {
            var dict = new Microsoft.AspNetCore.Routing.RouteValueDictionary(original ?? new { });
            foreach (var kv in new Microsoft.AspNetCore.Routing.RouteValueDictionary(newValues))
            {
                dict[kv.Key] = kv.Value;
            }
            return dict;
        }
    }
}
