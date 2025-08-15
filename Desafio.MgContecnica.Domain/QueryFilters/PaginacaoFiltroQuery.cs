namespace Desafio.MgContecnica.Domain.QueryFilters
{
    public class PaginacaoFiltroQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginacaoFiltroQuery()
        {
            PageNumber = 1;
            PageSize = 100;
        }

        public PaginacaoFiltroQuery(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 100 ? 100 : pageSize;
        }
    }
}
