namespace Desafio.MgContecnica.Application.Dto
{
    public record FiltroPaginacaoDto
    {
        public int? NumeroPagina { get; set; } = 1;
        public int? TamanhoPagina { get; set; } = 25;


        public void  ValidarPaginacao()
        {
            NumeroPagina = NumeroPagina < 1 ? 1 : NumeroPagina;
            TamanhoPagina = TamanhoPagina > 100 ? 100 : TamanhoPagina;
        }
    }
}
