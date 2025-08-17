using Desafio.MgContecnica.Application.ValidationAttributes;

namespace Desafio.MgContecnica.Application.Dto
{

    
    public class FiltroRelatorioDto
    {
        public DateOnly? DataInicial { get; set; }
        public DateOnly? DataFinal { get; set; }
    }
}
