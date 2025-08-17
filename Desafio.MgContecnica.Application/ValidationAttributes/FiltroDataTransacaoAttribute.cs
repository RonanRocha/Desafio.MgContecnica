using Desafio.MgContecnica.Application.Dto;
using System.ComponentModel.DataAnnotations;

namespace Desafio.MgContecnica.Application.ValidationAttributes
{
    public class FiltroDataTransacaoAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var dto = (FiltroTransacaoDto)validationContext.ObjectInstance;

            if (dto.DataInicial.HasValue && !dto.DataFinal.HasValue)
            {
                return new ValidationResult("Se a DataInicial for preenchida, a DataFinal também deve ser informada.");
            }

            if (!dto.DataInicial.HasValue && dto.DataFinal.HasValue)
            {
                return new ValidationResult("Se a DataFinal for preenchida, a DataInicial também deve ser informada.");
            }

            if (dto.DataInicial.HasValue && dto.DataFinal.HasValue && dto.DataInicial > dto.DataFinal)
            {
                return new ValidationResult("A DataInicial não pode ser maior que a DataFinal.");
            }

            return ValidationResult.Success;
        }
    }
}
