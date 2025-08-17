using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.MgContecnica.Application.Dto
{
    public record FiltroPaginacaoDto
    {
        public int? NumeroPagina { get; set; } = 1;
        public int? TamanhoPagina { get; set; } = 100;
    }
}
