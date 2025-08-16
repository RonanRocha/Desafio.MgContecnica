using System.ComponentModel.DataAnnotations;

namespace Desafio.MgContecnica.Application.ValidationAttributes
{
    public class DecimalGreaterThanZeroAttribute : ValidationAttribute
    {
        public DecimalGreaterThanZeroAttribute() : base("O campo {0} deve ser maior que zero")
        {
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            if (value is decimal decimalValue)
                return decimalValue > 0;

            return false;
        }
    }
}
