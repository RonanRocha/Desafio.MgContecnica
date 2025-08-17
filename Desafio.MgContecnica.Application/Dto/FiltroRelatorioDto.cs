using Desafio.MgContecnica.Application.ValidationAttributes;

namespace Desafio.MgContecnica.Application.Dto
{

    
    public class FiltroRelatorioDto
    {
        public DateOnly? DataInicial { get; set; }
        public DateOnly? DataFinal { get; set; }

        public int? NumeroPaginaDespesa { get; set; } = 1;
        public int? TotalPaginaDespesa { get; set; } = 100;
        public int? NumeroPaginaReceita { get; set; } = 1;
        public int? TotalPaginaReceita { get; set; } = 100;
    }
}
